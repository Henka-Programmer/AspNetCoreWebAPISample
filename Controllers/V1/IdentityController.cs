using AspNetCoreWebAPISample.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Requests;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Responses;
using AspNetCoreWebAPISample.WebAPI.Domain;

namespace Attandot.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var result = await _identityService.RegisterAsync(request.Email, request.Password);
            if (!result.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = result.ErrorMessage
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = result.Token,
                RefreshToken = result.RefreshToken
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<AuthenticationResult> LoginAsync([FromBody] UserLoginRequest request)
        {
            return await _identityService.LoginAsync(request.Email, request.Password);
        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        public async Task<AuthenticationResult> RefreshTokenRequest([FromBody] RefreshTokenRequest request)
        {
            return await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);
        }
    }


}
