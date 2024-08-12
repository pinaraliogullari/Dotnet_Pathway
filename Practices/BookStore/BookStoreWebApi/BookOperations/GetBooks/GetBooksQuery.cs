using AutoMapper;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            //List<BooksViewModel> viewModel = new List<BooksViewModel>();
            //viewModel=bookList.Select(book => new BooksViewModel()
            //{
            //    Title = book.Title,
            //    Genre = ((GenreEnum)book.GenreId).ToString(),
            //    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //    PageCount = book.PageCount,
            //}).ToList();

            List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookList);

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
