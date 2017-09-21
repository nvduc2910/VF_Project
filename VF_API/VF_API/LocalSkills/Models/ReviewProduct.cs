using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class ReviewProduct
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public DateTime CreatAt { get; set; }
        public double Rating { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
