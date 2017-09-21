using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int SkillId { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string LocationName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public bool IsCancel { get; set; }
        public double RateAvg { get; set; }
        public int TotalRate { get; set; }
        public long  TotalView { get; set; }


        // Relationship

        public Skill Skill { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ProductSchedule> ProductSchedules { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        public virtual ICollection<ProductRemainder> ProductRemainders { get; set; }
        public virtual ICollection<ProductAttender> ProductAttender { get; set; }
    }
}
