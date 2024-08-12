using AutoMapper;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreWebApi.BookOperations.GetBook.GetBookQuery;
using static BookStoreWebApi.BookOperations.GetBooks.GetBooksQuery;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));


        }
    }
}
