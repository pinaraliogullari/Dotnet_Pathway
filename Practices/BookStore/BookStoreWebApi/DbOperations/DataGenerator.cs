using BookStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre { Name = "Personal Growth" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Novel" }
                    );
                context.Books.AddRange(
                        new Book()
                        {
                            //Id = 1,
                            Title = "Lean Startup",
                            GenreId = 1,
                            PageCount = 200,
                            PublishDate = new DateTime(2001, 06, 12)

                        },
                        new Book
                        {
                            //Id = 2,
                            Title = "Herland",
                            GenreId = 2,
                            PageCount = 300,
                            PublishDate = new DateTime(2004, 07, 15)

                        },
                        new Book
                        {
                            //Id = 3,
                            Title = "Dune",
                            GenreId = 2,
                            PageCount = 400,
                            PublishDate = new DateTime(2010, 05, 23)

                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
