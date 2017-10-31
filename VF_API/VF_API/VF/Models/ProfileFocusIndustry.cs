using System;
namespace VF_API.Models
{
    public class ProfileFocusIndustry
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int FocusIndustryId { get; set; }

        public FocusIndustry FocusIndustry { get; set; }
        public Profile Profile { get; set; }

    }
}
