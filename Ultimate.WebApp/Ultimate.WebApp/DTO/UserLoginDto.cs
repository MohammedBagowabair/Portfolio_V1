using System.ComponentModel.DataAnnotations;

namespace Ultimate.Bot.Application.DTO
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}