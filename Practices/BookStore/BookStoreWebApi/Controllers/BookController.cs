using AutoMapper;
using BookStoreWebApi.BookOperations.CreateBook;
using BookStoreWebApi.BookOperations.DeleteBook;
using BookStoreWebApi.BookOperations.GetBook;
using BookStoreWebApi.BookOperations.GetBooks;
using BookStoreWebApi.BookOperations.UpdateBook;
using BookStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreWebApi.BookOperations.GetBook.GetBookQuery;
using static BookStoreWebApi.BookOperations.UpdateBook.UpdateBookCommand;

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

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
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
            try
            {
                GetBookQuery query = new(_context,_mapper);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{

        //    var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new(_context,_mapper);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] UpdateBookViewModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new(_context);
                command.Model = updatedBook;
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                DeleteBookCommand command = new(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    
            return Ok();
        }
    }
}
