using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class CategoryIdNotExistException : Exception
    {
        public CategoryIdNotExistException(string message) : base(message)
        {

         }
    }
}
