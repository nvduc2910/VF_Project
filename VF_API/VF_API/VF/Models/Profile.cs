using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VF_API.Enums;

namespace VF_API.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int? CompanySizeId { get; set; }
        public int? CharterCapitalId { get; set; }
        public int? RevenueId { get; set; }
        public int? ProductionCapacityId { get; set; }
        public int? MarketId { get; set; }
        public UserRole RoleId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int FoundedYear { get; set; }
        public string Vision { get; set; }
        public string Address { get; set; }
        public string CompanyDesciption { get; set; }
        public string TypicalProduct { get; set; }
        public string WebSite { get; set; }
        public string EmailContact { get; set; }
        public string PhoneNumberContact { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }

        public string ProductDescription { get; set; }
        public string ProductRequirement { get; set; }
        public int TotalProductNeeded { get; set; }
        public int Price { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public CharterCapital CharterCapital { get; set; }
        public CompanySize CompanySize { get; set; }
        public Revenue Revenue { get; set; }
        public ProductionCapacity ProductionCapacity { get; set; }
        public Market Market { get; set; }
        public virtual ICollection<ProfileScopeBusiness> ProfileScopeBusiness { get; set; }
    }
}
