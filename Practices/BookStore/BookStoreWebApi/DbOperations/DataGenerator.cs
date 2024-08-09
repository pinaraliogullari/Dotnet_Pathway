using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.DbOperations
{
    public  class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                        new Book()
                        {
                            Id = 1,
                            Title = "Lean Startup",
                            GenreId = 1, //PersonalGrowth
                            PageCount = 200,
                            PublishDate = new DateTime(2001, 06, 12)

                        },
                        new Book
                        {
                            Id = 2,
                            Title = "Herland",
                            GenreId = 2, //Science Fiction
                            PageCount = 300,
                            PublishDate = new DateTime(2004, 07, 15)

                        },
                         new Book
                         {
                             Id = 3,
                             Title = "Dune",
                             GenreId = 2, //Science Fiction
                             PageCount = 400,
                             PublishDate = new DateTime(2010, 05, 23)

                         }
                    );
            }
        }
    }
}
