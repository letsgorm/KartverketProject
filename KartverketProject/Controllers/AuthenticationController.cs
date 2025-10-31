using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;

namespace KartverketProject.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase 
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }


        // POST: api/authentication/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            if (await _context.Users.AnyAsync(u => u.Username == newUser.Username))
            {
                return BadRequest("Username already exists.");
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully.");

        }


        // POST: api/authentication/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (existingUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            else
            {
                return Ok("Login successful."); 
            }
        }
    }
}
