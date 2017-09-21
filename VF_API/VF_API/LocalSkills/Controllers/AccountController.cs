using System.Linq;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VF_API.Controllers
{
    /// <summary>
    /// This class is used as an api for the 
    /// requests 1.
    /// </summary>
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

        /// <summary>
        /// Contructor
        /// </summary>
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IFacebookProvider facebookProvider, IOptions<JwtIssuerOptions> jwtOptions, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpCotext, IGooglePlusProvider googleProvider, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.facebookProvider = facebookProvider;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.httpCotext = httpCotext;
            jwtIssuerOptions = jwtOptions.Value;
            this.googleProvider = googleProvider;
            this.emailSender = emailSender;
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
        /// Login with facebook
        /// </summary>
        /// <param name="externalLoginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginModel externalLoginModel)

        {
            UserInfoModel userInfoModel = new UserInfoModel();

            if (externalLoginModel.Provider == ExternalProvider.Facebook)
                userInfoModel = await facebookProvider.GetUserInfoAsync(externalLoginModel.AccessToken);

            else if(externalLoginModel.Provider == ExternalProvider.Google)
            {
                var userGoogleResponse = await googleProvider.GetUserInfoAsync(externalLoginModel.AccessToken);

                userInfoModel.FullName = userGoogleResponse.Name;
                userInfoModel.Avatar = userGoogleResponse.Avatar;
                userInfoModel.Email = userGoogleResponse.Id + "@google.com";
            }
            
            ApplicationUser applicationUser = await userManager.FindByEmailAsync(userInfoModel.Email);

            bool isFirstTime = false;

            if (applicationUser == null)
            {
                isFirstTime = true;
                applicationUser = await RegisterUser(userInfoModel.Email, userInfoModel.Avatar, null, userInfoModel.FullName, null, externalLoginModel.DeviceToken);

                if (applicationUser == null)
                    throw new FailedRegistrationException(FailureReturnMessages.RegisterFailed);
            }

            applicationUser.DeviceToken = externalLoginModel.DeviceToken;

            await unitOfWork.GetRepository<ApplicationUser>().UpdateAsync(applicationUser);

            return await RespondJwtTokenTo(applicationUser, isFirstTime);
        }

        /// <summary>
        /// Register with server
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            ApplicationUser user = await RegisterUser(registerModel.Email, registerModel.Avatar, registerModel.Password, registerModel.FullName, registerModel.BirthDay, registerModel.DeviceToken);
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

        #region Update Profile 

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileBindingModel profileModel)
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));

            var applicationUser = unitOfWork.GetRepository<ApplicationUser>().Get(s => s.Id == userId).FirstOrDefault();

            applicationUser.Avatar = profileModel.Avatar;
            applicationUser.FullName = profileModel.FullName;
            applicationUser.AboutMe = profileModel.AboutMe;
            applicationUser.Languages = profileModel.Languages;
            applicationUser.Job = profileModel.Job;
            applicationUser.PhoneNumber = profileModel.PhoneNumber;
            applicationUser.Email = profileModel.Email;
            applicationUser.Paymeninfo = profileModel.PaymentInfo;
            applicationUser.PayoutInfo = profileModel.PayoutInfo;
            applicationUser.LocationName = profileModel.LocationName;
            applicationUser.Lat = profileModel.Lat;
            applicationUser.Long = profileModel.Long;

            await unitOfWork.GetRepository<ApplicationUser>().UpdateAsync(applicationUser);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, profileModel);

        }
        #endregion

        #region GetProfile 

        [HttpGet]
        public IActionResult GetProfile(int id)
        {
            var applicationUserProfile = unitOfWork.GetRepository<ApplicationUser>().Get(s => s.Id == id, null, "Skills").FirstOrDefault();

            var profileReturn = new ProfileReturnModel();

            profileReturn.Avatar = applicationUserProfile.Avatar;
            profileReturn.FullName = applicationUserProfile.FullName;
            profileReturn.AboutMe = applicationUserProfile.AboutMe;
            profileReturn.Languages = applicationUserProfile.Languages;
            profileReturn.Job = applicationUserProfile.Job;
            profileReturn.PhoneNumber = applicationUserProfile.PhoneNumber;
            profileReturn.Email = applicationUserProfile.Email;
            profileReturn.PaymentInfo = applicationUserProfile.Paymeninfo;
            profileReturn.PayoutInfo = applicationUserProfile.PayoutInfo;
            profileReturn.LocationName = applicationUserProfile.LocationName;
            profileReturn.Lat = applicationUserProfile.Lat;
            profileReturn.Long = applicationUserProfile.Long;

            profileReturn.Skills = new System.Collections.Generic.List<SkillReturnModel>();

            foreach(var item in applicationUserProfile.Skills)
            {
                var skillItem = new SkillReturnModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.SkillImage,               
                };
                profileReturn.Skills.Add(skillItem);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, profileReturn);
        }

        #endregion

        #region Mehods

        [NonAction]
        private async Task<ApplicationUser> RegisterUser(string email, string avatar, string password, string fullName, string birthday, string deviceToken)
        {
            ApplicationUser user = new ApplicationUser() { Email = email, UserName = email, Avatar = avatar, FullName = fullName, Birthday = birthday, DeviceToken = deviceToken };

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
                avatar = user.Avatar,
                
            });
        }

        #endregion
    }
}
