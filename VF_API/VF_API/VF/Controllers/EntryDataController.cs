using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VF_API.Models;
using VF_API.Repository;
using VF_API.Infrastructures;
using VF_API.Helpers;
using VF_API.Models.BindingModels.EntryDataModels;
using VF_API.CustomAttribute;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [HandleException]
    [ValidateModel]
    public class EntryDataController : BaseController
    {
        public EntryDataController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {

        }

        [HttpPost]
        public async Task<IActionResult> InsertScopeBusiness([FromBody] List<ScopeBusinessBindModel> scopeBusiness)
        {
            foreach (var item in scopeBusiness)
            {
                var newScope = new ScopeBusiness()
                {
                    NameVI = item.NameVI,
                    NameEN = item.NameEN
                };
                await unitOfWork.GetRepository<ScopeBusiness>().InsertAsync(newScope);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Insert OK!");
        }

        [HttpPost]
        public async Task<IActionResult> InsertCompanySize([FromBody]List<ScopeBusinessBindModel> scopeBusiness)
        {
            foreach (var item in scopeBusiness)
            {
                var newScope = new CompanySize()
                {
                    NameVI = item.NameVI,
                    NameEN = item.NameEN
                };
                await unitOfWork.GetRepository<CompanySize>().InsertAsync(newScope);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Insert OK!");
        }

        [HttpPost]
        public async Task<IActionResult> InsertCharterCapital([FromBody]List<ScopeBusinessBindModel> scopeBusiness)
        {
            foreach (var item in scopeBusiness)
            {
                var newScope = new CharterCapital()
                {
                    NameVI = item.NameVI,
                    NameEN = item.NameEN
                };
                await unitOfWork.GetRepository<CharterCapital>().InsertAsync(newScope);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Insert OK!");
        }

        [HttpPost]
        public async Task<IActionResult> InsertRevenue([FromBody]List<ScopeBusinessBindModel> scopeBusiness)
        {
            foreach (var item in scopeBusiness)
            {
                var newScope = new Revenue()
                {
                    NameVI = item.NameVI,
                    NameEN = item.NameEN
                };
                await unitOfWork.GetRepository<Revenue>().InsertAsync(newScope);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Insert OK!");
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductionCapacity([FromBody]List<ScopeBusinessBindModel> scopeBusiness)
        {
            foreach (var item in scopeBusiness)
            {
                var newScope = new ProductionCapacity()
                {
                    NameVI = item.NameVI,
                    NameEN = item.NameEN
                };
                await unitOfWork.GetRepository<ProductionCapacity>().InsertAsync(newScope);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Insert OK!");
        }

    }
}
