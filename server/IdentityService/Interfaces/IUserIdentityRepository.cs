using SparkSwim.Core.Models;
using SparkSwim.IdentityService.Models;

namespace SparkSwim.IdentityService.Interfaces
{
    public interface IUserIdentityRepository
    {
        public Task<AppUser> ValidateUserByEmail(UserLoginDto userLoginDto);
    }
}
