using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.Core.Models;
using SparkSwim.UserManagementService.Controllers.Base;
using SparkSwim.UserManagementService.Models;

namespace SparkSwim.UserManagementService.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UserController : BaseController
    {
        private UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IdentityResult> Register(RegisterUserDto registerUserModel)
        {
            var appUser = new AppUser()
            {
                UserName = registerUserModel.UserName,
                Email = registerUserModel.Email,
                FirstName = registerUserModel.FirstName,
                LastName = registerUserModel.LastName
            };
            var result = await _userManager.CreateAsync(appUser, registerUserModel.Password);
            return result;
        }

        [HttpPost("update-user")]
        public async Task<IdentityResult> UpdateUser(UpdateUserDto updateUser)
        {
            var userToBeUpdated = await _userManager.FindByIdAsync(UserId.ToString());

            userToBeUpdated.UserName = updateUser.UserName;
            userToBeUpdated.Email = updateUser.Email;
            userToBeUpdated.FirstName = updateUser.FirstName;
            userToBeUpdated.LastName = updateUser.LastName;

            var result = await _userManager.UpdateAsync(userToBeUpdated);
            return result;
        }

        [HttpGet("health")]
        public async Task<string> Helth()
        {
            return "Service is online!";
        }

        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            return Ok(UserId.ToString());
        }
    }
}
