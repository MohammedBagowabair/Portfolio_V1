using System.ComponentModel.DataAnnotations;

namespace CamLine_Project.Models
{
    public class RegistraionForm
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter your First Name..")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please Enter your Last Name..")]
        [Display(Name = "last Name")]
        public string lastName { get; set; }


        [Required(ErrorMessage = "Please Enter your Email...")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
