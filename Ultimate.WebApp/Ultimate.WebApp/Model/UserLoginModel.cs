using System.ComponentModel.DataAnnotations;

namespace Ultimate.WebApp.Model
{
    public class UserLoginModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
