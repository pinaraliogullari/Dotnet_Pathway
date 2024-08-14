using AutoMapper;
using BookStoreWebApi.DbOperations;

namespace BookStoreWebApi.Application.GenreOperations.Queries.GetGenre
{
    public class GetGenreQuery
    {
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId && x.IsActive);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");
            GenreViewModel data = _mapper.Map<GenreViewModel>(genre);
            return data;
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
