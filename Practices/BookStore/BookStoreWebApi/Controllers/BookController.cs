using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title="Lean Startup",
                GenreId = 1, //PersonalGrowth
                PageCount=200,
                PublishDate= new DateTime(2001,06,12)

            },
            new Book
            {
                Id = 2,
                Title="Herland",
                GenreId = 2, //Science Fiction
                PageCount=300,
                PublishDate= new DateTime(2004,07,15)

            },
             new Book
            {
                Id = 3,
                Title="Dune",
                GenreId = 2, //Science Fiction
                PageCount=400,
                PublishDate= new DateTime(2010,05,23)

            },
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList= BookList.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        //[HttpGet]
        //public Book Get([FromQuery]string id)
        //{
            
        //    var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        //    return book;
        //}
    }
}
