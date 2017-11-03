using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels.AuthenticationModels
{
    public class FactoryAccountRegisterBindModel
    {

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyEmail")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmtpyCompanyName")]
        public string CompanyName { get; set; }

       


        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmpltyAddress")]
        public string Address { get; set; }


        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmpltyPhoneNumber")]
        public string PhoneNumber { get; set; }


       
        public bool IsLookingCustomer { get; set; }


        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyPassword")]
        public string Password { get; set; }
        public string DeviceToken { get; set; }


    }
}
