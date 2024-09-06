using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                    serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.UsersTypes.Any() || context.UsersGenders.Any()) return;

                context.UsersTypes.AddRange(
                    new UserType { Name = "Admin" },
                    new UserType { Name = "Bibliotekar" }
                );

                context.UsersGenders.AddRange(
                    new UserGender { Name = "Zensko"},
                    new UserGender { Name = "Musko"}
                );

                context.SaveChanges();
            }
        }
    }
}
