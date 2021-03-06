﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels.ProfileBindModels
{
    public class BusinessProfileBindModel
    {
        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmtpyCompanyName")]
        public string CompanyName { get; set; }


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmtpyFoundedYear")]
        public int FoundedYear { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyVision")]
        public string Vision { get; set; }


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyAddress")]
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public List<int> FocusIndustry { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyCompanyDesciption")]
        public string CompanyDesciption { get; set; }

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


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyPhoneNumber")]
        public string PhoneNumberContact { get; set; }


        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyProductDescription")]
        public string ProductDescription { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyProductDescription")]
        public string ProductRequirement { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyTotalProductNeeded")]
        public int TotalProductNeeded { get; set; }

        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationModel),
        ErrorMessageResourceName = "NullEmptyPrice")]
        public int PriceId { get; set; }

    }
}
