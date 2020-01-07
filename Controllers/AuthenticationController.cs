using DotNetWebApiSeed.Interfaces;
using DotNetWebApiSeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetWebApiSeed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        IAuthenticationService authenticationService){
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _authenticationService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}