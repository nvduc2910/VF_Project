using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.ReturnModels
{
    public class SkillDetialsReturnModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SkillImage { get; set; }
        public List<SkillDocument> DocumentSkills { get; set; }
        public List<ProductBriefReturn> Products { get; set; }
    }
}
