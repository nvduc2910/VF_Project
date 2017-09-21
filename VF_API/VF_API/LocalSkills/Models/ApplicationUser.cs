using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

namespace VF_API.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string FacebookId { get; set; }
        public string Birthday { get; set; }
        public string AboutMe { get; set; }
        public string Languages { get; set; }
        public string Job { get; set; }
        public string Paymeninfo { get; set; }
        public string LocationName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string PayoutInfo { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int PinCode { get; set; }
        public DateTime? PinCodeExpiration { get; set; }
        public string DeviceToken {get;set;}
        public virtual ICollection<FavoriteProduct> FavoriteProduct { get; set; }
        public virtual ICollection<ProductAttender> ProductAttender { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}
