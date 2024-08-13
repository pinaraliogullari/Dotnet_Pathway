using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorViewModel Handle()
        {
            var author= _context.Authors.Include(x=>x.Books).SingleOrDefault(x=>x.Id==AuthorId);
            if (author == null)
                throw new InvalidOperationException("Yazar bulunamadı");

            var authorVm= _mapper.Map<AuthorViewModel>(author);
            return authorVm;
        }

        public class AuthorViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public List<string> Books { get; set; }
        }
    }
}
