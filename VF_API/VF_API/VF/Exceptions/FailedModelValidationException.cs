﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class FailedModelValidationException : Exception
    {
        public FailedModelValidationException(string message) : base(message)
        {

        }
    }
}
