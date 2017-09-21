using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class ProductAttender
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Product Product { get; set; }
    }
}
