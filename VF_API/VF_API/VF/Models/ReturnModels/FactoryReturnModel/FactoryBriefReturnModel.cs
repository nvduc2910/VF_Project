using System;
using System.Collections.Generic;

namespace VF_API.Models.ReturnModels.FactoryReturnModel
{
    public class FactoryBriefReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string LocationName { get; set; }
        public bool IsFavorite { get; set; }
        public List<string> ScopeBusiness { get; set; }
    }
}
