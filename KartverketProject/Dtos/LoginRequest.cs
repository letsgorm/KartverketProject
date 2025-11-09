using System.ComponentModel.DataAnnotations;

namespace KartverketProject.Dtos
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please set an email")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Please set a password")]
        public string Password { get; set; } = "";
    }
}
