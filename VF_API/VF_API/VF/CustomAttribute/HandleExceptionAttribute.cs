using VF_API.Exceptions;
using VF_API.Helpers;
using VF_API.Infrastructures;
using VF_API.Resources;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VF_API.CustomAttribute
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is FailedModelValidationException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.UnprocessableEntity,
                    new[] { context.Exception.Message }, ErrorCodes.ValidationError);
            if (context.Exception is FailedRegistrationException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.NotImplemented,
                    new[] { context.Exception.Message }, ErrorCodes.RegisterFailed);
            else if (context.Exception is UserNotExistsException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.NotFound,
                    new[] { context.Exception.Message }, ErrorCodes.UserNotFound);
            else if (context.Exception is IncorrectPasswordException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.NotFound,
                    new[] { context.Exception.Message }, ErrorCodes.IncorrectPassword);

            else if (context.Exception is InvalidPinCodeException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.BadRequest,
                    new[] { context.Exception.Message }, ErrorCodes.InvalidPinCode);

            else if (context.Exception is PinCodeExpiredException)
                context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.BadRequest,
                    new[] { context.Exception.Message }, ErrorCodes.PinCodeExpired);

            else
            context.Result = ApiResponder.RespondFailureTo(HttpStatusCode.InternalServerError,
                    new[] {context.Exception.Message}, ErrorCodes.GeneralCode);
        }
    }
}
