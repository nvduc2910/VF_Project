using System;
using System.Collections.Generic;

namespace VF_API.Models.BindingModels.FilterBindModels
{
    public class NormalFilterBindModel
    {
        public string Key { get; set; }
        public List<int> ScopeBusinesses { get; set; }
        public List<int> CityId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
