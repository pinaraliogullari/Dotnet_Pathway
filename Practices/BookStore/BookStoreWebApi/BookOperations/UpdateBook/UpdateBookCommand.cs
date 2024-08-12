using AutoMapper;
using BookStoreWebApi.DbOperations;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;

namespace BookStoreWebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookViewModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _context.SaveChanges();
        }

        public class UpdateBookViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
