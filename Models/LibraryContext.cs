using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserGender> UsersGenders { get; set; }
        public DbSet<UserType> UsersTypes { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Bibliotekar> Bibliotekari { get; set; }

    }
}
