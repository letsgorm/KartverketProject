using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace KartverketProject.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase 
    {
        private readonly UserService _service;

        // registrer db kontekst
        public AuthenticationController(UserService service)
        {
            _service = service;
        }

        // GET: /api/authentication
        // hent bruker
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: /api/authentication/{id}
        // hent bruker med id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST: /api/authentication
        // legg til bruker
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User newUser)
        {
            var user = await _service.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        // PUT: /api/authentication/{id}
        // endre bruker
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _service.UpdateUserAsync(user);
            return NoContent();
        }

        // DEL: /api/authentication/{id}
        // slett en bruker i db
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _service.DeleteUserAsync(id);
            return NoContent();
        }

        // POST: api/authentication/register
        // sjekk om brukernavn er tatt
        [HttpPost("register")]
        public async Task<IActionResult> Register(User newUser)
        {
            if (await _service.UserExistsAsync(newUser))
            {
                return BadRequest("Username already exists.");
            }

            await _service.AddUserAsync(newUser);
            return Ok("User registered successfully.");

        }

        // POST: api/authentication/login
        // login med brukernavn og passord
        [HttpPost("login")]
        public async Task<IActionResult> Login(User loginRequest)
        {
            var existingUser = await _service.UserLoginAsync(loginRequest);

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
