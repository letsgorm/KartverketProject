using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KartverketProject.Models
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? FullName { get; set; }

        [MaxLength(100)]
        public string? Department { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<Report> ReportEntries { get; set; } = new List<Report>();
    }
}
