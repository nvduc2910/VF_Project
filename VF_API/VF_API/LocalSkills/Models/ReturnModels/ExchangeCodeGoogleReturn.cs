using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VF_API.Models.ReturnModels
{
    public class ExchangeCodeGoogleReturn
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
