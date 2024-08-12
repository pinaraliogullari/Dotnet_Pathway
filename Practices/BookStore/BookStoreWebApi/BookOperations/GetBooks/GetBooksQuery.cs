using BookStoreWebApi.Common;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBooksQuery(BookStoreDbContext context)
        {
            _context = context;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> viewModel = new List<BooksViewModel>();
            viewModel=bookList.Select(book => new BooksViewModel()
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount,
            }).ToList();

            return viewModel;
        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
