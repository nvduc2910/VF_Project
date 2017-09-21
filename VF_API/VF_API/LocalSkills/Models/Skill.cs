using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class Skill
    {
        public int ApplicationUserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SkillImage { get; set; }
        public virtual ICollection<SkillDocument> SkillDocument { get; set; }

        public Skill()
        {

        }

        public Skill(int applicationId, string name, string description, string skillImage)
        {
            this.ApplicationUserId = applicationId;
            this.Name = name;
            this.Description = description;
            this.SkillImage = skillImage;
        }
    }
}
