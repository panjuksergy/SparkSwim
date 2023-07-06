using Microsoft.AspNetCore.Identity;
using SparkSwim.Core.Models;
using SparkSwim.IdentityService.Interfaces;
using SparkSwim.IdentityService.Models;
using System.Text;

namespace SparkSwim.IdentityService.Services
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private UserManager<AppUser> _userManager;

        public UserIdentityRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> ValidateUserByEmail(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var result = user != null && await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            return result ? user : null;
        }
    }
}
