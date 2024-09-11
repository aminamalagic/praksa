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
                new UserType { Id = 1, Name = "Bibliotekar" },
                new UserType { Id = 2, Name = "Učenik" }
                );

                context.UsersGenders.AddRange(
                    new UserGender { Name = "Zenski"},
                    new UserGender { Name = "Muski"}
                );

                context.SaveChanges();
                Console.WriteLine("Data has been seeded");
            }
        }
    }
}
