using AuthencationService.Services;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthencationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public LoginController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login model)
        {
            // Replace with actual user validation
            if (model.Username == "test" && model.Password == "password")
            {
                var token = _jwtService.GenerateToken(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
