using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VF_API.Resources;

namespace VF_API.Models.BindingModels
{
    public class PersonalAccountRegisterBindModel
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
            ErrorMessageResourceName = "NullEmpltyFullName")]
        public string FullName { get; set; }

        
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyPassword")]
        public string Password { get; set; }
        public string DeviceToken { get; set; }
    }
}
