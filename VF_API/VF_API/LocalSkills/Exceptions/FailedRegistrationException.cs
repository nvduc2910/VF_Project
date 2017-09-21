using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class FailedRegistrationException : Exception
    {
        public FailedRegistrationException(string message) : base(message) { }
    }
}
