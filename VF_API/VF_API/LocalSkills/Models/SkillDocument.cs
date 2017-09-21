using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models
{
    public class SkillDocument
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string DocumentPath { get; set; }

      

        public SkillDocument(int skillId, string documentPath)
        {
            this.SkillId = skillId;
            this.DocumentPath = documentPath;
        }

        public SkillDocument()
        {

        }
    }
}
