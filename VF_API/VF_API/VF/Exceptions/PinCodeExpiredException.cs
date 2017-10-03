using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class PinCodeExpiredException : Exception
    {
        /// <summary>
        /// Pin code expired exception constructor
        /// </summary>
        /// <param name="message"></param>
        public PinCodeExpiredException(string message) : base(message)
        {

        }
    }
}
