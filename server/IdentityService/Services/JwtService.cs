using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SparkSwim.Core.Models;
using SparkSwim.IdentityService.Configuration;
using SparkSwim.IdentityService.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SparkSwim.IdentityService.Services
{
    public class JwtService : IJwtService
    {
        private TimeSpan _expirityDuration = new TimeSpan(0, 30, 0);

        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;

        public JwtService(IOptions<JwtConfiguration> options)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key));
            _issuer = options.Value.Issuer;
        }

        public async Task<string> CreateTokenAsync(string id, string email, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
            claims.Add(new Claim(ClaimTypes.Email, email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var jwt = new JwtSecurityToken(
                claims: claims,
                issuer: _issuer,
                audience: "Audience",
                expires: DateTime.UtcNow.Add(_expirityDuration),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
