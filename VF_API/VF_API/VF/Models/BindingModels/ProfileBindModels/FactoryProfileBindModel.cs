using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels.ProfileBindModels
{
    public class FactoryProfileBindModel
    {
        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmtpyCompanyName")]
        public string CompanyName { get; set; }

        public List<int> ScopeBusinesses { get; set; }

        public string TypicalProduct { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmtpyFoundedYear")]
        public int FoundedYear { get; set; }


        //[Required(
        //AllowEmptyStrings = false,
        //ErrorMessageResourceType = typeof(ValidationModel),
        //ErrorMessageResourceName = "NullEmptyVision")]
        //public string Vision { get; set; }


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyAddress")]
        public string Address { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }

        [Required(
         AllowEmptyStrings = false,
         ErrorMessageResourceType = typeof(ValidationModel),
         ErrorMessageResourceName = "NullEmptyWebsite")]
        public string WebSite { get; set; }


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyEmail")]
        public string EmailContact { get; set; }


        public int CompanySizeId { get; set; }
        public int CharterCapitalId { get; set; }
        public int RevenueId { get; set; }
        public int ProductionCapacityId { get; set; }
        public int MarketId { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyPhoneNumber")]
        public string PhoneNumberContact { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyCompanyDesciption")]
        public string CompanyDesciption { get; set; }

    }
}
