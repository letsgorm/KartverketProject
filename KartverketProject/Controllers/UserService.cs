using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// This is the CRUD service for Obstacle.
// AuthenticationController
// AccountController

namespace KartverketProject.Controllers
{
    [Authorize(Roles = "admin")] // kun admin!
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // Hent alle brukere
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        // Hent bruker med ID
        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        // Opprett ny bruker
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            // Opprett bruker via UserManager slik at passord blir kryptert
            return await _userManager.CreateAsync(user, password);
        }

        // Oppdater bruker (uten passord)
        public async Task UpdateUserAsync(User updatedUser)
        {
            var existingUser = await _userManager.FindByIdAsync(updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Email = updatedUser.Email;
                existingUser.UserName = updatedUser.UserName;
                existingUser.Active = updatedUser.Active;

                await _userManager.UpdateAsync(existingUser);
            }
        }

        // Slett bruker
        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
        }

        // Sjekk om brukernavn eksisterer
        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }

        // Logg inn
        public async Task<SignInResult> UserLoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return SignInResult.Failed;

            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }
    }
}