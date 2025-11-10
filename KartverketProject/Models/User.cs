using Microsoft.AspNetCore.Identity;

namespace KartverketProject.Models
{
    public class User : IdentityUser
    {
        public string? Department { get; set; }

        public bool Active { get; set; } = true;
    }
}