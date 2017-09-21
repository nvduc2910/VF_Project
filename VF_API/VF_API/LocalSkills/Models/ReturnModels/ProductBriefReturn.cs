using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.ReturnModels
{
    public class ProductBriefReturn
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
