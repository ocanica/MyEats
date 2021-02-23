using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEats.Business.Models;
using MyEats.Business.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace MyEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Login controller")]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AuthenticateRequest model)
        {
            var response = _authenticationService.Authenticate(model);

            if (response == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(response);
        }
    }
}
