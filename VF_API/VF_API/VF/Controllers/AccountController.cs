﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VF_API.Models;
using Microsoft.AspNetCore.Identity;
using VF_API.Models.BindingModels;
using VF_API.Infrastructures;
using VF_API.Exceptions;
using VF_API.Resources;
using VF_API.Helpers;
using VF_API.CustomAttribute;
using VF_API.Options;
using VF_API.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using VF_API.Repository;
using System;
using Microsoft.AspNetCore.Http;
using VF_API.Models.ReturnModels;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    /// <summary>
    /// This class is used as an api for the 
    /// requests 1.
    /// </summary>
    /// 

    [Route("api/[controller]/[Action]")]
    [ValidateModel]
    [HandleException]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtIssuerOptions jwtIssuerOptions;
        private readonly IFacebookProvider facebookProvider;
        private readonly IGooglePlusProvider googleProvider;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpCotext;
        private readonly IEmailSender emailSender;
        private const int PinCodeExpirationTime = 24;
        private readonly IStringLocalizer<ValidationModel> localizer;


        /// <summary>
        /// Contructor
        /// </summary>
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IFacebookProvider facebookProvider, IOptions<JwtIssuerOptions> jwtOptions, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpCotext, IGooglePlusProvider googleProvider, IEmailSender emailSender, IStringLocalizer<ValidationModel> localizer)
        {
            this.userManager = userManager;
            this.facebookProvider = facebookProvider;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.httpCotext = httpCotext;
            jwtIssuerOptions = jwtOptions.Value;
            this.googleProvider = googleProvider;
            this.emailSender = emailSender;
            this.localizer = localizer;
        }



        [HttpGet]
        public string Test()
        {
            return localizer["InvalidEmail"];
        }

        /// <summary>
        /// Login with server
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
                throw new UserNotExistsException(FailureReturnMessages.UserNotFound);

            bool result = await userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!result)
                throw new IncorrectPasswordException(FailureReturnMessages.IncorrectPassword);

            user.DeviceToken = loginModel.DeviceToken;

            await unitOfWork.GetRepository<ApplicationUser>().UpdateAsync(user);

            return await RespondJwtTokenTo(user, false);
        }


        /// <summary>
        /// Register with server
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterPersonalAccount([FromBody] PersonalAccountRegisterBindModel personalModel)
        {
            ApplicationUser user = await RegisterPersonalUser(personalModel.Email, personalModel.Password,  personalModel.FullName, personalModel.CompanyName, personalModel.DeviceToken);
            if (user == null)
                throw new FailedRegistrationException(FailureReturnMessages.RegisterFailed);

            return await RespondJwtTokenTo(user, false);
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ApplicationUser currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(FailureReturnMessages.UserNotFound);

            int pinCode = new Random().Next(100000, 999999);
            currentUser.PinCode = pinCode;
            currentUser.PinCodeExpiration = DateTime.UtcNow.AddHours(PinCodeExpirationTime);

            IdentityResult updateUserResult = await userManager.UpdateAsync(currentUser);

            if (!updateUserResult.Succeeded)
                throw new IdentityException(updateUserResult.Errors.FirstOrDefault().Description);

            string message = System.IO.File.ReadAllText(@"./HtmlPages/Email.html");

            await emailSender.SendEmailAsync(email, "Pin Code Confirmation",
                String.Format(message, currentUser.UserName, pinCode.ToString()));

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Please check your email to setup new password");
        }


        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> ResetPassword(string email, string newPassword, int pinCode)
        {
            ApplicationUser currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(FailureReturnMessages.UserNotFound);

            if (currentUser.PinCode != pinCode)
                throw new InvalidPinCodeException(FailureReturnMessages.InvalidPinCode);

            if (currentUser.PinCodeExpiration < DateTime.UtcNow)
                throw new PinCodeExpiredException(FailureReturnMessages.PinCodeExpired);

            IdentityResult deletePasswordResult = await userManager.RemovePasswordAsync(currentUser);

            if (!deletePasswordResult.Succeeded)
                throw new IdentityException(deletePasswordResult.Errors.FirstOrDefault().Description);

            IdentityResult addPasswordResult = await userManager.AddPasswordAsync(currentUser, newPassword);

            if (!addPasswordResult.Succeeded)
                throw new IdentityException(addPasswordResult.Errors.FirstOrDefault().Description);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Update new password sucessfully");
        }
       

        #region Mehods
        [NonAction]
        private async Task<ApplicationUser> RegisterPersonalUser(string email, string password, string fullName, string companyName, string deviceToken)
        {
            ApplicationUser user = new ApplicationUser() { Email = email, UserName = email, FullName = fullName, CompanyName = companyName, DeviceToken = deviceToken };

            IdentityResult userCreationResult = password == null
                ? await userManager.CreateAsync(user)
                : await userManager.CreateAsync(user, password);

            if (!userCreationResult.Succeeded)
                throw new IdentityException(userCreationResult.Errors.FirstOrDefault().Description);

            return user;
        }

        [NonAction]
        private async Task<ObjectResult> RespondJwtTokenTo(ApplicationUser user, bool isFirstTime)
        {
            ClaimsPrincipal principal = await signInManager.CreateUserPrincipalAsync(user);
            string encodedJwt = JwtEncoder.EncodeSecurityToken(jwtIssuerOptions, principal);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, new
            {
                access_token = encodedJwt,
                full_name = user.FullName,
                user_id = user.Id,
                first_time = isFirstTime,
            });
        }

        #endregion
    }
}