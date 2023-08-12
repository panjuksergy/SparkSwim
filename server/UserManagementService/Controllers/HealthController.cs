using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.UserManagementService.Controllers.Base;

namespace SparkSwim.UserManagementService.Controllers
{
    public class HealthController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("ItsWorking");
        }

        [HttpGet("admincheck")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AdminCheck()
        {
            return Ok("User is admin");
        }
    }
}
