using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Helpers
{
    public static class HttpStatusCode
    {
        //Success Status Code
        public const int Ok = 200;

        //Error Status Code
        public const int BadRequest = 400;
        public const int UnprocessableEntity = 422;
        public const int NotImplemented = 501;
        public const int NotFound = 404;
        public const int InternalServerError = 500;
    }
}
