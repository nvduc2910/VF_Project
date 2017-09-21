using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels
{
    public class ProductBindingModel
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
        public List<string> ProductPhotos { get; set; }
        public List<ProductScheduleBindingModel> ProductSchedules { get; set; }

        public List<string> ProductRemainder { get; set; }
       
    }


    public class ProductPhotoBindingModel
    {
        public string ImagePath { get; set; }
    }

    public class ProductScheduleBindingModel
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ProductRemainderBindingModel
    {
        public string Content { get; set; }
    }
}
