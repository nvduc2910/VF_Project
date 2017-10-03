using VF_API.Helpers;
using VF_API.Infrastructures;
using VF_API.Resources;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace VF_API.CustomAttribute
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        private readonly IStringLocalizer<ValidationModel> localizer;

        public ValidateModelAttribute()
        {
            
        }


        public ValidateModelAttribute(IStringLocalizer<ValidationModel> localizer)
        {
            this.localizer = localizer;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<string> validationErrors = ErrorBuilder.BuildInvalidModelStateError(context.ModelState);
            

            if (validationErrors != null && validationErrors.Count > 0)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.UnprocessableEntity, validationErrors,
                    ErrorCodes.ValidationError);
        }
    }
}
