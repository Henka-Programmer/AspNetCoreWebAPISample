using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Domain;

namespace AspNetCoreWebAPISample.WebAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}