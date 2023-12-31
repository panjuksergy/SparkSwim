﻿using Microsoft.AspNetCore.Identity;
using SparkSwim.Core.Models;
using System.Data;

namespace SparkSwim.IdentityService.Interfaces
{
    public interface IJwtService
    {
        public Task<string> CreateTokenAsync(string id, string email, IEnumerable<string> roles);
    }
}
