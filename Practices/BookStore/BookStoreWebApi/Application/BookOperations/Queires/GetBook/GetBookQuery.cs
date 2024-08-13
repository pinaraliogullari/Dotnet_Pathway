using AutoMapper;
using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queires.GetBook
{
    public class GetBookQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
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
        }
    }
}
