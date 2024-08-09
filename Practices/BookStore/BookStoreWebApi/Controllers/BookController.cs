﻿using BookStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;

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

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{

        //    var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
                return BadRequest(book);

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
