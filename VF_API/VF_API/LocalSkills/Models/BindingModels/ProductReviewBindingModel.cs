using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels
{
    public class ProductReviewBindingModel
    {
        public int ProductId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
    }
}
