using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VF_API.CustomAttribute;
using VF_API.Helpers;
using VF_API.Infrastructures;
using VF_API.Models;
using VF_API.Models.BindingModels.FilterBindModels;
using VF_API.Models.ReturnModels.FactoryReturnModel;
using VF_API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    [HandleException]
    public class FilterController : BaseController
    {
        public FilterController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {
            
        }

        [HttpPost]
        public IActionResult NormalFilter([FromBody] NormalFilterBindModel normalfileModel)
        {
            
            var factoriesReturn = new List<FactoryBriefReturnModel>();
            bool isEnableFavorite = false;
            Expression<Func<Profile, bool>> filter;
            var userId = Convert.ToInt32(userManager.GetUserId(User));

            if (userId != 0)
                isEnableFavorite = true;

            filter = s0 => (s0.CompanyName.ToLower().Contains(normalfileModel.Key.ToLower())
                || s0.ProfileScopeBusiness.Any(r => normalfileModel.ScopeBusinesses.Contains(r.ScopeBusinessId))
                || normalfileModel.CityId.Contains(s0.CityId))

                || (s0.ProfileScopeBusiness.Any(r => r.ScopeBusiness.NameVI.ToLower().Contains(normalfileModel.Key.ToLower()) || r.ScopeBusiness.NameEN.ToLower().Contains(normalfileModel.Key.ToLower()))
                    || s0.ProfileScopeBusiness.Any(r => normalfileModel.ScopeBusinesses.Contains(r.ScopeBusinessId))
                    || normalfileModel.CityId.Contains(s0.CityId));


            var resultNumber = unitOfWork.GetContext().Profile.Where(filter).Count();
            var profileFavorite = unitOfWork.GetRepository<ProfileFavorite>().Get(s => s.ApplicationUserId == userId).ToList();
            var factories = unitOfWork.GetRepository<Profile>().Get(filter, null, "ProfileScopeBusiness.ScopeBusiness").Skip((normalfileModel.Page - 1) * normalfileModel.PageSize).Take(normalfileModel.PageSize).ToList();

            foreach (var item in factories)
            {
                var factoryBriefReturn = new FactoryBriefReturnModel()
                {
                    Id = item.Id,
                    Name = item.CompanyName,
                    LocationName = item.Address,
                    IsFavorite = profileFavorite.Any(s => s.ApplicationUserId == userId && s.ProfileId == item.Id) ? true : false,
                };
                factoryBriefReturn.ScopeBusiness = new List<string>();
                foreach(var itemScopeBusiness in item.ProfileScopeBusiness)
                {
                    if(HeaderLanguage() == "en-US")
                        factoryBriefReturn.ScopeBusiness.Add(itemScopeBusiness.ScopeBusiness.NameEN);
                    else if(HeaderLanguage() == "vi")
                        factoryBriefReturn.ScopeBusiness.Add(itemScopeBusiness.ScopeBusiness.NameVI);
                }

                factoriesReturn.Add(factoryBriefReturn);
            }


            var factoriesObjectReturn = new
            {
                ResultNumber = resultNumber,
                Factories = factoriesReturn,
                IsEnableFavorite = isEnableFavorite,
            };

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, factoriesObjectReturn);

        }


        //[HttpPost]
        //public IActionResult AdvanceFilter()
        //{
            
        //}
    }
}
