using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var deletedAuthor = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (deletedAuthor == null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı");

            var authorsbook = _context.Books.Where(x => x.Id == AuthorId).Any();
            if (authorsbook) 
                throw new InvalidProgramException("Yazarın yayında olan kitapları mevcut.");

 
            _context.Authors.Remove(deletedAuthor);
            _context.SaveChanges();
        }
    }
}
