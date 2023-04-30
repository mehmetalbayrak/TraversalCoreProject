
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="girilen şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
    }
}
