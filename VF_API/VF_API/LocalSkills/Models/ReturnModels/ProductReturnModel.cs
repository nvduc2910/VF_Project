using VF_API.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.ReturnModels
{
    public class ProductReturnModel
    {
        public int SkillId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string LocationName { get; set; }
        public bool IsCancel { get; set; }
        public int UserId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAvatar { get; set; }
        public double RateAvg { get; set; }
        public int TotalRate { get; set; }
        public bool IsFav { get; set; }

        public List<string> ProductPhotos { get; set; }
        public List<ProductScheduleBindingModel> ProductSchedules { get; set; }
        public List<string> ProductRemainder { get; set; }
    }
}
