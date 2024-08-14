using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStore.UnitTest.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
             new Book() { Title = "Lean Startup", GenreId = 1, AuthorId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
             new Book { Title = "Herland", GenreId = 2, AuthorId = 1, PageCount = 300, PublishDate = new DateTime(2004, 07, 15) },
             new Book { Title = "Dune", GenreId = 2, AuthorId = 2, PageCount = 400, PublishDate = new DateTime(2010, 05, 23) }
             );
        }
    }
}
