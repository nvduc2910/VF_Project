using Newtonsoft.Json;

namespace VF_API.Models.ReturnModels
{
    public class UserGooglePlusReturn
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Avatar { get; set; }
    }
}
