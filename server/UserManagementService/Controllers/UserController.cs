using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.Core.Models;
using SparkSwim.UserManagementService.Controllers.Base;
using SparkSwim.UserManagementService.Models;

namespace SparkSwim.UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseController
    {
        private UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
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

        [HttpPost("update")]
        public async Task<IdentityResult> Update(UpdateUserDto updateUser)
        {
            var userToBeUpdated = await _userManager.FindByIdAsync(UserId.ToString());

            userToBeUpdated.Email = userToBeUpdated.Email;
            userToBeUpdated.UserName = userToBeUpdated.UserName;
            userToBeUpdated.FirstName = updateUser.FirstName;
            userToBeUpdated.LastName = updateUser.LastName;

            var result = await _userManager.UpdateAsync(userToBeUpdated);
            return result;
        }

        [HttpPost("changepassword")]
        public async Task<IdentityResult> ChangePassword(ChangePasswordDto changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var result = await _userManager.ChangePasswordAsync
                (user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);

            return result;
        }

        [HttpPost("remove")]
        public async Task<IdentityResult> RemoveByUserName(string userName)
        {
            var userToBeDeleted = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.DeleteAsync(userToBeDeleted);

            return result;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<AppUser>> GetAll()
        {
            var result = _userManager.Users.AsEnumerable();
            return result;
        }

        [HttpGet("get")]
        public async Task<AppUser> GetByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
    }
}
