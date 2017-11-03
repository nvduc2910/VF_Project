using System;
namespace VF_API.Models
{
    public class ProfileFavorite
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int ProfileId { get; set; }
    }
}
