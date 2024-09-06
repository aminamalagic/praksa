using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime i prezime")]
        [RegularExpression(@"^[a-zA-Z]+\s[a-zA-Z]+$", ErrorMessage = "Unesite puno ime i prezime.")]
        public string Name { get; set; }

        [Display(Name= "Tip korisnika")]
        public long User_type_id { get; set; }
        [ForeignKey("User_type_id")]
        public UserType UserType { get; set; }

        [Display(Name = "Pol")]
        public long User_gender_id { get; set; }
        [ForeignKey("user_gender_id")]
        public UserGender UserGender { get; set; }
        public int JMBG { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Photo { get; set; }

        public bool Email_verified { get; set; }

        public string Remember_token { get; set; }

        public DateTime Last_login_at { get; set; }

        public int Login_count { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        public bool Active { get; set; }
    }
}
