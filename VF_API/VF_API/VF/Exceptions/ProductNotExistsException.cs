using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class ProductNotExistsException : Exception
    {
        public ProductNotExistsException(string message) : base(message) { }
    }
}
