using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class Converstation
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecevierId { get; set; }
        public int TotalMessage { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastDate { get; set; }


        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recevier { get; set; }




    }
}
