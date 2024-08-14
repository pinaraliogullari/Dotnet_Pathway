using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queires.GetBook;
using BookStoreWebApi.Application.BookOperations.Queires.GetBooks;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStoreWebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static BookStoreWebApi.Application.BookOperations.Queires.GetBook.GetBookQuery;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Static data

        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book()
        //    {
        //        Id = 1,
        //        Title="Lean Startup",
        //        GenreId = 1, //PersonalGrowth
        //        PageCount=200,
        //        PublishDate= new DateTime(2001,06,12)

        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Title="Herland",
        //        GenreId = 2, //Science Fiction
        //        PageCount=300,
        //        PublishDate= new DateTime(2004,07,15)

        //    },
        //     new Book
        //    {
        //        Id = 3,
        //        Title="Dune",
        //        GenreId = 2, //Science Fiction
        //        PageCount=400,
        //        PublishDate= new DateTime(2010,05,23)

        //    },
        //}; 
        #endregion

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new(_context, _mapper);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookViewModel result;

            GetBookQuery query = new(_context, _mapper);
            query.BookId = id;
            GetBookValidator validator = new();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new(_context, _mapper);

            command.Model = newBook;
            CreateBookValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] UpdateBookViewModel updatedBook)
        {
            UpdateBookCommand command = new(_context);
            command.Model = updatedBook;
            command.BookId = id;
            UpdateBookValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            DeleteBookCommand command = new(_context);
            command.BookId = id;
            DeleteBookValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
