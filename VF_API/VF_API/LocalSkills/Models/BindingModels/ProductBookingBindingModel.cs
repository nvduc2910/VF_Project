using VF_API.Models.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Models.BindingModels
{
    public class ProductBookingReturnModel
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public List<ReviewReturnModel> Reviews { get; set; }
        public List<AttenderReturnModel> Attenders { get; set; }
        public string Required { get; set; }
        public string Policy { get; set; }

        public int OwnerId { get; set; }
        public string OwnerAvatar { get; set; }
        public string OwnerName { get; set; }
    }
}
