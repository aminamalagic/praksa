using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Bibliotekar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long User_type_id { get; set; }
        [ForeignKey("User_type_id")]
        public UserType UserType { get; set; }
        public string Email { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]
        public string Username { get; set; }


        public string Password { get; set; }
        public DateTime Last_login_at { get; set; }
    }
}
