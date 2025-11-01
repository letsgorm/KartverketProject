using System.ComponentModel.DataAnnotations;

namespace KartverketProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } //NB: Will be hashed later 
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        // liste av rapporter
        public ICollection<Report> ReportEntries { get; set; } = new List<Report>();
    }
}
