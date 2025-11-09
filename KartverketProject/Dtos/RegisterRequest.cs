using System.ComponentModel.DataAnnotations;

namespace KartverketProject.Dtos
{
    public class RegisterRequest
    {
        public string UserName { get; set; } = "";
        [Required(ErrorMessage = "Please set an email")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Please set a password")]
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
