using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.ReturnModels
{
    public class ConversationReturnModel
    {
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public string ReceiverName {get;set;}
        public DateTime LastDate { get; set; }

        public string Avatar { get; set; }
    }
}
