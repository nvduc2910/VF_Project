using System.ComponentModel.DataAnnotations;
using VF_API.Resources;

namespace VF_API.Models.BindingModels
{
    public class ExternalLoginModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "NullEmptyProvider")]
        public string Provider { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(FailureModelValidationMessages),
            ErrorMessageResourceName = "NullEmptyAccessToken")]
        public string AccessToken { get; set; }
        public string DeviceToken { get; set; }
    }
}
