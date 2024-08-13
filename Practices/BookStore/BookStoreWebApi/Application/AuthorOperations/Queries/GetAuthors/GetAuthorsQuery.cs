using AutoMapper;
using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.Include(x => x.Books).OrderBy(x => x.Id).ToList();
            var authorListVm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return authorListVm;
        }

        public class AuthorsViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public List<string> Books { get; set; }
        }
    }
}
