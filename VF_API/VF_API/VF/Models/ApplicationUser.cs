using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using VF_API.Enums;

namespace VF_API.Models
{
    public class ApplicationUser : IdentityUser<int>
    { 

        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public UserRole RoleId { get; set; }
        public int ProfileId { get; set; }

        //Factory
        public int ScopeBusinessId { get; set; }
        public string Address { get; set; }
        public bool IsLookingCustomer { get; set; }

        public bool IsCompleteProfile { get; set; }

        public int PinCode { get; set; }
        public DateTime? PinCodeExpiration { get; set; }
        public string DeviceToken {get;set;}

        public virtual ICollection<Message> Messages { get; set; }

    }
}
