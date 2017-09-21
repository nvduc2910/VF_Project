using System.Threading.Tasks;
using VF_API.Models.BindingModels;

namespace VF_API.Providers
{
    public interface IFacebookProvider
    {
        Task<UserInfoModel> GetUserInfoAsync(string accessToken);
    }
}
