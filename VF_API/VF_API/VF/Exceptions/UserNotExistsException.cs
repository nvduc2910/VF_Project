using System;

namespace VF_API.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException(string message) : base(message) { }
    }
}
