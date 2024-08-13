using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenre;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor.GetAuthorQuery;
using static BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static BookStoreWebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
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

            CreateMap<Author, AuthorViewModel>().ForMember(dest=>dest.Books,opt=>opt.MapFrom(src=>src.Books.Select(x=>x.Title).ToList()));
            CreateMap<Author, AuthorsViewModel>().ForMember(dest=>dest.Books,opt=>opt.MapFrom(src=>src.Books.Select(x=>x.Title).ToList()));
            CreateMap<CreateAuthorModel, Author>();
       


        }
    }
}
