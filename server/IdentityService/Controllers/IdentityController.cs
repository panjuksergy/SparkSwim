using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.Core.Models;
using SparkSwim.IdentityService.Interfaces;
using SparkSwim.IdentityService.Models;

namespace SparkSwim.IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IUserIdentityRepository _userIdentityRepository;
        private IJwtService _jwtService;

        public IdentityController(IJwtService jwtService, IUserIdentityRepository userIdentityRepository, 
            UserManager<AppUser> userManager)
        {
            _userIdentityRepository = userIdentityRepository;
            _jwtService = jwtService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginUserModel)
        {
            var user = await _userIdentityRepository.ValidateUserByEmail(loginUserModel);

            return user != null
                ? Ok(await _jwtService.CreateTokenAsync
                    (user.Id, user.Email, await _userManager.GetRolesAsync(user)))
                : Unauthorized();
        }
    }
}
