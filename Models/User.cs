using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    //[Table("AspNetUsers")]

    public class User : IdentityUser
    {
        //public string Id { get; set; }
        public string? Name { get; set; }
        public long? User_type_id { get; set; }
        [ForeignKey("User_type_id")]
        public UserType UserType { get; set; }
        public string? JMBG { get; set; }
        public DateTime? Last_login_at { get; set; }


        /*
        
        public bool Email_verified { get; set; }

        public DateTime Last_login_at { get; set; }
      
        public bool Active { get; set; }  
        
        public string Password { get; set; }

        public int? JMBG { get; set; }
         
        public string? Username { get; set; }

        public string? Photo { get; set; }

        public string? Remember_token { get; set; }

        public int? Login_count { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }
        
        */
    }
}
