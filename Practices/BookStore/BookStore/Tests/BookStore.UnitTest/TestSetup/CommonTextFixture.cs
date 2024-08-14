using AutoMapper;
using BookStoreWebApi.Common;
using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore.UnitTest.TestSetup
{
    public class CommonTextFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();
            Mapper = new MapperConfiguration(cfg =>{ cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }
    }
}
