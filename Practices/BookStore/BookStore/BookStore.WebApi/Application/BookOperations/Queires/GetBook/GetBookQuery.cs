using AutoMapper;
using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queires.GetBook
{
    public class GetBookQuery
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).OrderBy(x => x.Id).SingleOrDefault(book => book.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            //BookViewModel viewModel = new();
            //viewModel.Title = book.Title;
            //viewModel.PageCount = book.PageCount;
            //viewModel.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            //viewModel.Genre = ((GenreEnum)book.GenreId).ToString();
            BookViewModel viewModel = _mapper.Map<BookViewModel>(book);
            return viewModel;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }
    }
}
