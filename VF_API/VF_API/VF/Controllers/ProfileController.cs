using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VF_API.Models;
using VF_API.Repository;
using Microsoft.AspNetCore.Authorization;
using VF_API.CustomAttribute;
using VF_API.Models.ReturnModels.ProfileReturnModels;
using VF_API.Infrastructures;
using VF_API.Helpers;
using VF_API.Models.BindingModels.ProfileBindModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [HandleException]
    [ValidateModel]
    public class ProfileController : BaseController
    {
        public ProfileController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {

        }

        #region GET/ScopeBusiness

        [HttpGet]
        public IActionResult ScopeBusiness()
        {
            var language = this.HeaderLanguage();
            var scopeBusinesesReturn = new List<ScopeBusinessReturnModel>();
            var scopeBusinesses = unitOfWork.GetRepository<ScopeBusiness>().Get().ToList();

            if (language == "vi")
            {
                foreach(var item in scopeBusinesses)
                {
                    var scopeBusinessItemReturn = new ScopeBusinessReturnModel()
                    {
                        Id = item.Id,
                        Name = item.NameVI,
                    };
                    scopeBusinesesReturn.Add(scopeBusinessItemReturn);
                }
            }
            else if(language == "en-US")
            {
                foreach (var item in scopeBusinesses)
                {
                    var scopeBusinessItemReturn = new ScopeBusinessReturnModel()
                    {
                        Id = item.Id,
                        Name = item.NameEN,
                    };
                    scopeBusinesesReturn.Add(scopeBusinessItemReturn);
                }
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, scopeBusinesesReturn);

        }

        #endregion

        #region POST/ Update Personal Profile

        [HttpPost]
        public async Task<IActionResult> UpdatePersonalProfile([FromBody] PersonalProfileBindModel personalModel)
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));

            var personalAccount = new Profile()
            {
                ApplicationUserId = userId,
                RoleId = Enums.UserRole.Personal,
                CustomerName = personalModel.CustomerName,
                CompanyName = personalModel.CompanyName,
                FoundedYear = personalModel.FoundedYear,
                Vision = personalModel.Vision,
                Address = personalModel.Address,
                CompanyDesciption = personalModel.CompanyDesciption,
                WebSite = personalModel.WebSite,
                EmailContact = personalModel.EmailContact,
                PhoneNumberContact = personalModel.PhoneNumberContact,
                ProductDescription = personalModel.ProductDescription,
                ProductRequirement = personalModel.ProductRequirement,
                TotalProductNeeded = personalModel.TotalProductNeeded,
                Price = personalModel.Price,
                Lat = personalModel.Lat,
                Lng = personalModel.Lng,
            };

            await unitOfWork.GetRepository<Profile>().InsertAsync(personalAccount);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, personalAccount);
        }
        #endregion

        #region POST/ Update Business Profile

        [HttpPost]
        public async Task<IActionResult> UpdateBusinessProfile([FromBody] BusinessProfileBindModel businessModel)
        {
            using (var transaction = unitOfWork.GetContext().Database.BeginTransaction())
            {
                try
                {
                    var userId = Convert.ToInt32(userManager.GetUserId(User));

                    var businessProfile = new Profile()
                    {
                        ApplicationUserId = userId,
                        RoleId = Enums.UserRole.Business,
                        FoundedYear = businessModel.FoundedYear,
                        Vision = businessModel.Vision,
                        Address = businessModel.Address,
                        CompanyDesciption = businessModel.CompanyDesciption,
                        WebSite = businessModel.WebSite,
                        EmailContact = businessModel.EmailContact,
                        PhoneNumberContact = businessModel.PhoneNumberContact,
                        ProductDescription = businessModel.ProductDescription,
                        ProductRequirement = businessModel.ProductRequirement,
                        TotalProductNeeded = businessModel.TotalProductNeeded,
                        Price = businessModel.Price,
                        Lat = businessModel.Lat,
                        Lng = businessModel.Lng,
                    };

                    var businessProfileAdded = await unitOfWork.GetRepository<Profile>().InsertAsync(businessProfile);

                    foreach(var item in businessModel.ScopeBusinesses)
                    {
                        var profileScopeBuniness = new ProfileScopeBusiness()
                        {
                            ProfileId = businessProfileAdded.Id,
                            ScopeBusinessId = item,

                        };
                        await unitOfWork.GetRepository<ProfileScopeBusiness>().InsertAsync(profileScopeBuniness);
                    }
                    transaction.Commit();

                    return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Updated Business Account");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                   
                }
            }
            
        }

        #endregion

        #region POST/ Factory Business Profile

        [HttpPost]
        public async Task<IActionResult> UpdateFactoryProfile([FromBody] FactoryProfileBindModel factoryModel)
        {
            using (var transaction = unitOfWork.GetContext().Database.BeginTransaction())
            {
                try
                {
                    var userId = Convert.ToInt32(userManager.GetUserId(User));

                    var factoryProfile = new Profile()
                    {
                        ApplicationUserId = userId,
                        RoleId = Enums.UserRole.Factory,
                        CompanyName = factoryModel.CompanyName,
                        TypicalProduct = factoryModel.TypicalProduct,
                        Address = factoryModel.Address,
                        FoundedYear = factoryModel.FoundedYear,
                        CompanyDesciption = factoryModel.CompanyDesciption,
                        WebSite = factoryModel.WebSite,
                        EmailContact = factoryModel.EmailContact,
                        PhoneNumberContact = factoryModel.PhoneNumberContact,
                        CompanySizeId = factoryModel.CompanySizeId,
                        CharterCapitalId = factoryModel.CharterCapitalId,
                        ProductionCapacityId = factoryModel.ProductionCapacityId,
                        RevenueId = factoryModel.RevenueId,
                        MarketId = factoryModel.MarketId,
                        Lat = factoryModel.Lat,
                        Lng = factoryModel.Lng,
                    };

                    var businessProfileAdded = await unitOfWork.GetRepository<Profile>().InsertAsync(factoryProfile);

                    foreach (var item in factoryModel.ScopeBusinesses)
                    {
                        var profileScopeBuniness = new ProfileScopeBusiness()
                        {
                            ProfileId = businessProfileAdded.Id,
                            ScopeBusinessId = item,

                        };
                        await unitOfWork.GetRepository<ProfileScopeBusiness>().InsertAsync(profileScopeBuniness);
                    }
                    transaction.Commit();

                    return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Updated Factory Profile");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;

                }
            }

        }

        #endregion
    }
}
