using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.Core.Models;
using SparkSwim.UserManagementService.Controllers.Base;
using SparkSwim.UserManagementService.Models;

namespace SparkSwim.UserManagementService.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public Task<IdentityResult> Register(UserRegisterDto registerUserModel)
        {
            var appUser = new AppUser()
            {
                UserName = registerUserModel.UserName,
                Email = registerUserModel.Email,
                FirstName = registerUserModel.FirstName,
                LastName = registerUserModel.LastName
            };
            var result = _userManager.CreateAsync(appUser, registerUserModel.Password);
            return result;
        }
    }
}
