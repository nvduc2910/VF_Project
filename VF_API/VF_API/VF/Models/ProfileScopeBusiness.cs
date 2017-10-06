using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class ProfileScopeBusiness
    {
        public int Id { get; set; }
        public int ScopeBusinessId { get; set; }
        public int ProfileId { get; set; }
        public ScopeBusiness ScopeBusiness { get; set; }
        public Profile Profile { get; set; }
    }
}
