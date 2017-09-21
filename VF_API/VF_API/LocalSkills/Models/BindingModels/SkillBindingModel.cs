using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels
{
    public class SkillBindingModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<string> Document { get; set; }
    }
}
