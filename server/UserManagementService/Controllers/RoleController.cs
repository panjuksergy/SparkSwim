﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.UserManagementService.Controllers.Base;
using System.Data;

namespace SparkSwim.UserManagementService.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("add")]
        public async Task<IdentityResult> Add(IdentityRole role) 
        {
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        [HttpPost("update")]
        public async Task<IdentityResult> Update(IdentityRole role)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(role.Id);
            if (roleToUpdate == null)
            {
                return IdentityResult.Failed(new IdentityError() 
                { 
                    Description = $"Role {role.Name} was not found." 
                });
            }
                
            var result = await _roleManager.UpdateAsync(role);
            return result;
        }

        [HttpPost("remove")]
        public async Task<IdentityResult> Remove(IdentityRole role)
        {
            var result = await _roleManager.DeleteAsync(role);
            return result;
        }

        [HttpGet]
        public async Task<IdentityRole> Get(string name)
        {
            var result = await _roleManager.FindByNameAsync(name);
            return result;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<IdentityRole>> Get()
        {
            var result = _roleManager.Roles.AsEnumerable();
            return result;
        }
    }
}
