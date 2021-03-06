﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class InvalidPinCodeException : Exception
    {
        /// <summary>
        /// Invalid pin code exception constructor
        /// </summary>
        /// <param name="message"></param>
        public InvalidPinCodeException(string message) : base(message)
        {

        }
    }
}
