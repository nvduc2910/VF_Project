using VF_API.Models.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Providers
{
    public interface IGooglePlusProvider
    {
        Task<UserGooglePlusReturn> GetUserInfoAsync(string accessToken);
    }
}
