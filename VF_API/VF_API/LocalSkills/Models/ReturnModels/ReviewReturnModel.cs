using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.ReturnModels
{
    public class ReviewReturnModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAvatar { get; set; }
        public string ReviewContent { get; set; }
        public double Rating { get; set; }
    }
}
