using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Unesite Email adresu")]
        [EmailAddress]
        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Unesite lozinku")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Lozinka mora imati najmanje 8 karaktera.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

    }
}
