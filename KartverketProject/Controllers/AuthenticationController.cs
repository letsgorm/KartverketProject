using KartverketProject.Dtos;
using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;

// API controller for User

namespace KartverketProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthenticationController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/authentication
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/authentication/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/authentication/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = await _userService.AddUserAsync(user, model.Password);

            if (result.Succeeded)
                return Ok(new { Message = "User registered successfully!" });

            return BadRequest(result.Errors);
        }

        // POST: api/authentication/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _userService.UserLoginAsync(model.Email, model.Password);

            if (result.Succeeded)
                return Ok(new { Message = "Login successful!" });

            return Unauthorized(new { Message = "Invalid username or password." });
        }

        // PUT: api/authentication/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest();

            await _userService.UpdateUserAsync(updatedUser);
            return NoContent();
        }

        // DELETE: api/authentication/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
