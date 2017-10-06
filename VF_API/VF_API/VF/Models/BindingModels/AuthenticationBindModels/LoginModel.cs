using System.ComponentModel.DataAnnotations;
using VF_API.Resources;

namespace VF_API.Models.BindingModels
{
    public class LoginModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyEmail")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyPassword")]
        [StringLength(
            20,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "InvalidPassword",
            MinimumLength = 8)]
        public string Password { get; set; }

        public string DeviceToken { get; set; }
    }
}
