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
        public UserType UserType { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
