using BookStoreWebApi.Common;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.BookOperations.GetBook
{
    public class GetBookQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;

        public GetBookQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BookViewModel Handle()
        {
            var book = _context.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            BookViewModel viewModel = new();
            viewModel.Title = book.Title;
            viewModel.PageCount = book.PageCount;
            viewModel.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            viewModel.Genre = ((GenreEnum)book.GenreId).ToString();
            return viewModel;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
