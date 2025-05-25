using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ultimate.Bot.Application.DTO
{
    public class RegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
