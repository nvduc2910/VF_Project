using VF_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int ReceiverId { get; set; }
        public string Text { get; set; }
        public ChatType Type { get; set; } 
        public DateTime CreateAt { get; set; }

    }
}
