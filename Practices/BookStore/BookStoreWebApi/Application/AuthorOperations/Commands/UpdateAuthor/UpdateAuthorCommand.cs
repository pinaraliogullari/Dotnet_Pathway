using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorViewModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var updatedAuthor = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (updatedAuthor == null)
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı");
            updatedAuthor.FirstName = string.IsNullOrEmpty(Model.FirstName.Trim()) ? updatedAuthor.FirstName : Model.FirstName;
            updatedAuthor.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? updatedAuthor.LastName : Model.LastName;

            updatedAuthor.BirthDate = Model.BirthDate==default ? updatedAuthor.BirthDate : Model.BirthDate;
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
