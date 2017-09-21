using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels
{
    public class ProfileBindingModel
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string AboutMe { get; set; }
        public string Languages { get; set; }
        public string Job { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PaymentInfo { get; set; }
        public string PayoutInfo { get; set; }
        public string LocationName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
