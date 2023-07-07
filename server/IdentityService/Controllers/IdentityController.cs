using Microsoft.AspNetCore.Mvc;
using SparkSwim.IdentityService.Interfaces;
using SparkSwim.IdentityService.Models;

namespace SparkSwim.IdentityService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private IUserIdentityRepository _userIdentityRepository;
        private IJwtService _jwtService;

        public IdentityController(IJwtService jwtService, IUserIdentityRepository userIdentityRepository)
        {
            _userIdentityRepository = userIdentityRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginUserModel)
        {
            var user = await _userIdentityRepository.ValidateUserByEmail(loginUserModel);

            return user != null
                ? Ok(await _jwtService.CreateTokenAsync(user.Id, user.Email))
                : Unauthorized();
        }
    }
}
