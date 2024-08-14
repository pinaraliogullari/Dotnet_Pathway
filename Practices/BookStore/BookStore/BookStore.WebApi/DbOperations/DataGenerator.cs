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

                context.Authors.AddRange(
                    new Author { FirstName = "John", LastName = "Steinback", BirthDate = new DateTime(1875, 12, 5) },
                    new Author { FirstName = "George", LastName = "Orwell", BirthDate = new DateTime(1789, 10, 2) },
                    new Author { FirstName = "Lev", LastName = "Tolstoy", BirthDate = new DateTime(1828, 6, 28) }
                    );

                context.Books.AddRange(
                        new Book()
                        {
                            Title = "Lean Startup",
                            GenreId = 1,
                            AuthorId = 1,
                            PageCount = 200,
                            PublishDate = new DateTime(2001, 06, 12)

                        },
                        new Book
                        {
                            Title = "Herland",
                            GenreId = 2,
                            AuthorId = 1,
                            PageCount = 300,
                            PublishDate = new DateTime(2004, 07, 15)

                        },
                        new Book
                        {
                            Title = "Dune",
                            GenreId = 2,
                            AuthorId = 2,
                            PageCount = 400,
                            PublishDate = new DateTime(2010, 05, 23)

                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
