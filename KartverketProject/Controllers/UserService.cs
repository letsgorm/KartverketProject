using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// This is the CRUD service for Users.
// Edit the controller if you wish to make changes.

// AC = AuthenticationController

public class UserService
{
    private readonly ApplicationDbContext _context;

    // registrer db kontekst
    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    // gi alle brukere som liste
    // AC: GetUsers
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(o => o.ReportEntries) // inkluder relasjon
            .ToListAsync();
    }

    // finn brukere etter id som gir data eller default data
    // AC: GetUserById
    public async Task<User?> GetUserByIdAsync([FromBody] int id)
    {
        return await _context.Users
            .Include(o => o.ReportEntries) // inkluder relasjon
            .FirstOrDefaultAsync(o => o.UserId == id);
    }

    // returner brukere
    // AC: AddUser
    public async Task<User> AddUserAsync([FromBody] User user)
    {
        _context.Users.Add(user); // lag hindre forst foor data
        await _context.SaveChangesAsync();

        var report = new Report // lag ny data
        {
            ReportId = user.UserId
        };

        _context.Report.Add(report); // legg til data
        await _context.SaveChangesAsync();

        return user;
    }

    // oppdater brukere
    // AC: UpdateUser
    public async Task UpdateUserAsync([FromBody] User updatedUser)
    {
        var user = await _context.Users.FindAsync(updatedUser.UserId);
        if (user != null)
        {
            user.UserId = updatedUser.UserId;
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.Email = updatedUser.Email;
            user.Active = updatedUser.Active;
            await _context.SaveChangesAsync();
        }
    }

    // slett brukere
    // AC: RemoveUser
    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    // sjekk om brukernavn eksisterer
    // AC: Register
    public async Task<bool> UserExistsAsync([FromBody] User newUser)
    {
        return await _context.Users.AnyAsync(u => u.Username == newUser.Username);
    }

    // sjekk om bruker kan logge inn
    // AC: Login
    public async Task<User?> UserLoginAsync([FromBody] User loginRequest)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);
    }
}
