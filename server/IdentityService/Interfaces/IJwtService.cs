using SparkSwim.Core.Models;

namespace SparkSwim.IdentityService.Interfaces
{
    public interface IJwtService
    {
        public Task<string> CreateTokenAsync(string id, string email);
    }
}
