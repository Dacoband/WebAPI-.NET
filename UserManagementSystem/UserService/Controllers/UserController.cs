using Common.Models;
using Microsoft.AspNetCore.Mvc;
using UserService.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace UserService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserServiceClass _userService;

        public UserController(UserServiceClass userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userService.GetUserAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _userService.GetUserAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
