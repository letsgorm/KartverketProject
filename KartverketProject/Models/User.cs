using Microsoft.AspNetCore.Identity;

namespace KartverketProject.Models
{
    public class User : IdentityUser
    {
        // keep firstname and lastname nullable
        // theyre only for seeding data and wont work with login
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool Active { get; set; } = true;
    }
}
