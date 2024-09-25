using Microsoft.Build.Framework;

namespace Library.Models
{
    public class Genre
    {
        public int Id { get; set; }

       // [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
