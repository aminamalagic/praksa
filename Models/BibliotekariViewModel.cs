using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BibliotekariViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime i prezime")]
        [RegularExpression(@"^[a-zA-Z]+\s[a-zA-Z]+$", ErrorMessage = "Unesite puno ime i prezime.")]
        public string Name { get; set; }

        [Display(Name = "Tip korisnika")]
        public long User_type_id { get; set; }
        [ForeignKey("User_type_id")]

        [Required]
        [Display(Name = "JMBG")]
        public string JMBG { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Lozinka mora imati najmanje 8 karaktera.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

    }
}
