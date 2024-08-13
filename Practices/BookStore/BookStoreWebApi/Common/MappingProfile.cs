using AutoMapper;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenre;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStoreWebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static BookStoreWebApi.Application.BookOperations.Queires.GetBook.GetBookQuery;
using static BookStoreWebApi.Application.BookOperations.Queires.GetBooks.GetBooksQuery;
using static BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
     
           
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();


        }
    }
}
