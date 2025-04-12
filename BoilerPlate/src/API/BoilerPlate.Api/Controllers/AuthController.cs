using Asp.Versioning;
using BoilerPlate.Application.Interfaces.Identity;
using BoilerPlate.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Api.Controllers
{
    
    [Route("api/v{version:apiVersion}/[controller]")]
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : Controller
        {
            readonly IAuthService _authService;
            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }
            [HttpPost("login")]
            public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
            {
                var response = await _authService.Login(authRequest);
                return Ok(response);
            }
            [HttpPost("register")]
            public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
            {
                var response = await _authService.Register(request);
                return Ok(response);
            }
        }
    
}
