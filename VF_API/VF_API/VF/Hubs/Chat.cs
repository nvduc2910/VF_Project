using VF_API.Enums;
using VF_API.Infrastructures;
using VF_API.Models;
using VF_API.Models.ReturnModels;
using VF_API.Repository;
using VF_API.Services.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;


namespace VF_API.Hubs
{
    [HubName("chat")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class Chat : Hub
    {
        #region Fields
        private IHttpContextAccessor contextAccessor;
        private static List<UserConnection> users = new List<UserConnection>();
        private VfDbContext dataContext = null;

        protected VfDbContext DataContext
        {
            get {
               
                if(dataContext != null)
                {
                    return dataContext;
                }
                else
                {
                    var options = new DbContextOptionsBuilder<VfDbContext>();
                    options.UseSqlServer("Server=tcp:beauty-advisor.database.windows.net,1433;Initial Catalog=VF_API;Persist Security Info=False;User ID=beautyadvisor;Password=Sofus71204;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    dataContext =  new VfDbContext(options.Options);
                    return dataContext;
                }

            }
        }

        #endregion

        #region Contructors
        public Chat( IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork, VfDbContext context )
        {
            this.contextAccessor = contextAccessor;
        }
        #endregion

        #region Setup

        public override Task OnConnected()
        {

            var userId = contextAccessor.HttpContext.Request.Headers["Authorization"];
            var connectId = Context.ConnectionId;


            Console.WriteLine("Connected: " + userId);

            var userConnect = new UserConnection()
            {
                UserName = userId,
                ConnectionID = connectId,
            };

            var itemUser = users.Find(s => s.ConnectionID == connectId);
            if (itemUser == null)
            {
                users.Add(userConnect);
            }
            return base.OnConnected();
        }


        public override Task OnReconnected()
        {
            var userId = contextAccessor.HttpContext.Request.Headers["Authorization"];
            var connectId = Context.ConnectionId;

            Console.WriteLine("Reconnected: " + userId);

            var userConnect = new UserConnection()
            {
                UserName = userId,
                ConnectionID = connectId,
            };

            var itemUser = users.Find(s => s.ConnectionID == connectId);
            if (itemUser == null)
            {
                users.Add(userConnect);
            }
            return base.OnReconnected();

        }
        public override Task OnDisconnected(bool stopCalled)
        {
            var userId = contextAccessor.HttpContext.Request.Headers["Authorization"];
            var connectId = Context.ConnectionId;

            Console.WriteLine("Disconnect: " + userId);

            var userConnect = new UserConnection()
            {
                UserName = userId,
                ConnectionID = connectId,
            };

            var itemUser = users.Find(s => s.ConnectionID == connectId);

            if (itemUser != null)
            {
                users.Remove(itemUser);
            }
            return base.OnDisconnected(stopCalled);
        }


        #endregion

        #region Action Send Message

        public async Task<ApiResponder> SendMessage(string userName, string deviceID,
            string senderUserId, string toUserId, string message,
            string messageKey, ChatType chatType = ChatType.Text)
        {
            try
            {
                Console.WriteLine("sending a message: " + message);

                var newMessage = new Message()
                {
                    ApplicationUserId = Convert.ToInt32(senderUserId),
                    ReceiverId = Convert.ToInt32(toUserId),
                    Text = message,
                    CreateAt = DateTime.UtcNow,
                    Type = chatType
                };

                var itemUser = users.Find(s => s.UserName == toUserId);

                if (itemUser != null)
                {
                    Clients.Client(itemUser.ConnectionID).messageReceived(newMessage);
                }
               
                    var pushNotification = new OneSignalService();
                    pushNotification.PushNotification(newMessage, userName, deviceID, senderUserId);
                

                var conversatition = DataContext.Converstation.Where(s => (s.SenderId == Convert.ToInt32(senderUserId) && s.RecevierId == Convert.ToInt32(toUserId)) || (s.SenderId == Convert.ToInt32(toUserId) && s.RecevierId == Convert.ToInt32(senderUserId))).FirstOrDefault();

                if (conversatition == null)
                {
                    var conversationItem = new Converstation()
                    {
                        SenderId = Convert.ToInt32(senderUserId),
                        RecevierId = Convert.ToInt32(toUserId),
                        LastMessage = message,
                        LastDate = DateTime.UtcNow,
                        TotalMessage = 1,
                    };

                    DataContext.Converstation.Add(conversationItem);
                }
                else
                {
                    conversatition.TotalMessage = conversatition.TotalMessage + 1;
                    conversatition.LastDate = DateTime.UtcNow;
                    conversatition.LastMessage = message;

                    DataContext.Converstation.Update(conversatition);
                }

                DataContext.Message.Add(newMessage);

                await DataContext.SaveChangesAsync();

                var messageReturn = new MessageReturnModel()
                {
                    ApplicationUserId = newMessage.ApplicationUserId,
                    ReceiverId = newMessage.ReceiverId,
                    Text = newMessage.Text,
                    CreateAt = DateTime.UtcNow,
                    Type = chatType,
                    MessageKey = messageKey,
                };

                var sucessMessage = new ApiResponder(messageReturn, null);

                Console.WriteLine("send Successfully");

                return sucessMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                var errorMessage = new ApiResponder(null, new Error() { errorCode = 5001, errorMessage = new string[] { ex.Message } });
                return errorMessage;
            }

        }
        #endregion
    }

    public class UserConnection
    {
        public string UserName { set; get; }
        public string ConnectionID { set; get; }
    }
}
