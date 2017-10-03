using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class CrudFailedException : Exception
    {
        public CrudFailedException(string message) : base(message)
        {

        }
    }
}
