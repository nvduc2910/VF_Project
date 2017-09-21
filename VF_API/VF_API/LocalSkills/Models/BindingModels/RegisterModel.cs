using System.ComponentModel.DataAnnotations;
using VF_API.CustomAttribute;
using VF_API.Resources;

namespace VF_API.Models.BindingModels
{
    public class RegisterModel
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

        public string Avatar { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "NullEmptyConfirmedPassword")]
        [StringLength(
            20, 
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "InvalidConfirmedPassword",
            MinimumLength = 8)]
        [MatchForPassword(
            nameof(Password),
            nameof(ConfirmedPassword),
            ErrorMessageResourceType = typeof(FailureModelValidationMessages), 
            ErrorMessageResourceName = "ConfirmedPasswordNotMatchForPassword")]
        public string ConfirmedPassword { get; set; }

        public string FullName { get; set; }

        public string BirthDay { get; set; }

        public string DeviceToken { get; set; }
    }
}
