using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VF_API.CustomAttribute;
using VF_API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using VF_API.Models;
using VF_API.Infrastructures;
using VF_API.Helpers;
using VF_API.Exceptions;
using VF_API.Resources;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using VF_API.Models.ReturnModels;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize()]
    [HandleException]
    public class ChatController : BaseController
    {
        public ChatController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {

        }

        [HttpGet]
        public IActionResult GetDeviceToken(int userId)
        {
            var user = unitOfWork.GetRepository<ApplicationUser>().Get(s => s.Id == userId).FirstOrDefault();

            if (user == null)
                throw new UserNotExistsException(FailureReturnMessages.UserNotFound);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, user);

        }


        [HttpGet]
        public IActionResult ChatHistory(int userId, int page, int pageSize, int totalSkipItem)
        {
            var myUserId = Convert.ToInt32( userManager.GetUserId( User));
            var messageHistory = unitOfWork.GetRepository<Message>().Get(s => (s.ApplicationUserId == myUserId && s.ReceiverId == userId) || (s.ApplicationUserId == userId && s.ReceiverId == myUserId)).OrderByDescending(s => s.Id).Skip(totalSkipItem + ((page - 1) * pageSize)).Take(pageSize).ToList();

            var messageFinal = messageHistory.OrderBy(s => s.Id);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, messageFinal);
        }


        [HttpGet]
        public IActionResult Converstation()
        {
            var myUserId = Convert.ToInt32(userManager.GetUserId(User));
            var conversationReturn = new List<ConversationReturnModel>();

            var converstationsMySenders = unitOfWork.GetRepository<Converstation>().Get(s => s.SenderId == myUserId, null, "Recevier").ToList();

            foreach(var item in converstationsMySenders)
            {
                var itemReturn = new ConversationReturnModel()
                {
                    ReceiverId = item.Recevier.Id,
                    Message = item.LastMessage,
                    ReceiverName = item.Recevier.FullName,
                    LastDate = item.LastDate,
                    Avatar = item.Recevier.Avatar,
                };
                conversationReturn.Add(itemReturn);
            }


            var converstationsOrtherSenders = unitOfWork.GetRepository<Converstation>().Get(s => s.RecevierId == myUserId, null, "Sender").ToList();

            foreach (var item in converstationsOrtherSenders)
            {
                var itemReturn = new ConversationReturnModel()
                {
                    ReceiverId = item.Sender.Id,
                    Message = item.LastMessage,
                    ReceiverName = item.Sender.FullName,
                    LastDate = item.LastDate,
                    Avatar = item.Sender.Avatar,
                };
                conversationReturn.Add(itemReturn);
            }


            //foreach(var item in converstationsMySenders)
            //{
            //    foreach(var item1 in converstationsOrtherSenders)
            //    {
            //        if(item.SenderId == item1.RecevierId && item.RecevierId == item1.SenderId)
            //        {
            //            var itemRemove = conversationReturn.Find(s => s.ReceiverId == item.RecevierId);
            //            conversationReturn.Remove(itemRemove);
            //        }
            //    }
            //}

            var returnFinal = conversationReturn.OrderByDescending(s => s.LastDate);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, returnFinal);
        }

        [HttpGet]
        public async Task<IActionResult> TestPushMessage(string deviceToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://onesignal.com");
                    client.DefaultRequestHeaders.Add("authorization", "Basic NDBmZWQyZDktNDIwZi00NWMxLWEzZWQtODUzMGMxNzhhM2Ez");

                    var obj = new
                    {
                        app_id = "e97913c0-0f01-4bac-8fc0-4fecfb87d8f2",
                        contents = new { en = "Duc Nguyen" + ": " + "Ich nhau nhe" },
                        data = new {userid = 1},
                        include_player_ids = new string[] { deviceToken }
                    };

                    var jsonPost = JsonConvert.SerializeObject(obj);

                    var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("/api/v1/notifications", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                }

                return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Push ok");
            }
            catch (Exception ex)
            {
                return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Push ok");
            }
        }
    }
}
