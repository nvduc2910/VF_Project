using System.ComponentModel.DataAnnotations;
using VF_API.Resources;

namespace VF_API.Models.BindingModels
{
    public class LoginModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "NullEmptyEmail")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "NullEmptyPassword")]
        [StringLength(
            20,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "InvalidPassword",
            MinimumLength = 8)]
        public string Password { get; set; }

        public string DeviceToken { get; set; }
    }
}
