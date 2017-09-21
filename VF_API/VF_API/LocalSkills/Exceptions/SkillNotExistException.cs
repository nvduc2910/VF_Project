using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Exceptions
{
    public class SkillNotExistException : Exception
    {
        public SkillNotExistException(string message) : base(message) { }
    }
}
