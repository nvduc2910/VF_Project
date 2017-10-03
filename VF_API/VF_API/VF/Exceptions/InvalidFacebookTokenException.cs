using System;

namespace VF_API.Exceptions
{
    public class InvalidFacebookTokenException : Exception
    {
        public InvalidFacebookTokenException(string message) : base(message)
        {
        }
    }
}
