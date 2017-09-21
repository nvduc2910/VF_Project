using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class FavoriteProduct
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
    }
}
