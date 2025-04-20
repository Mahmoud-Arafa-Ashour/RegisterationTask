using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RegisterationTask.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController(IAuthServices authServices) : ControllerBase
    {
        private readonly IAuthServices _authServices = authServices;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var authResponse = await _authServices.GetTokenAsync(request.Email, request.Password, cancellationToken);
            return authResponse.IsSuccess ? Ok(authResponse.Value) : authResponse.ToProblem();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto request, CancellationToken cancellationToken)
        {
            var authResponse = await _authServices.RegisterAsync(request, cancellationToken);
            return authResponse.IsSuccess ? Ok(authResponse.Value) : authResponse.ToProblem();
        }
    }
}
