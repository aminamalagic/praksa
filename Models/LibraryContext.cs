using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Models
{
    public class LibraryContext : IdentityDbContext<User>
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        //public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserGender> UsersGenders { get; set; }
        public DbSet<UserType> UsersTypes { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Bibliotekar> Bibliotekari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bibliotekar>()
                .HasOne(b => b.UserType)
                .WithMany(u => u.Bibliotekari)
                .HasForeignKey(b => b.User_type_id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Library.Models.SignUpUserModel> SignUpUserModel { get; set; } = default!;

    }
}
