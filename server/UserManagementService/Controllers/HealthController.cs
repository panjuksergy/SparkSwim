using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.UserManagementService.Controllers.Base;

namespace SparkSwim.UserManagementService.Controllers
{
    [Route("identity")]
    public class HealthController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok($"{UserId}");
        }
    }
}
