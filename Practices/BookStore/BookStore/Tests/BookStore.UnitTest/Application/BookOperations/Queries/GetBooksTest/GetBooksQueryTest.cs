using AutoMapper;
using BookStore.UnitTest.TestSetup;
using BookStoreWebApi.Application.BookOperations.Queires.GetBooks;
using BookStoreWebApi.DbOperations;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;
using static BookStoreWebApi.Application.BookOperations.Queires.GetBooks.GetBooksQuery;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookStore.UnitTest.Application.BookOperations.Queries.GetBooksTest
{
    public class GetBooksQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryTest(CommonTextFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public void WhenGetBooksQueryIsWorked_BookListShouldBeReturned()
        {
            GetBooksQuery query = new(_context, _mapper);

            var result = FluentActions.Invoking(() => query.Handle()).Invoke();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new List<BooksViewModel>
            {
                new BooksViewModel
                {
                    Title = "Lean Startup",
                    Genre = "Personel Growth",
                    Author = "John SteinBack",
                    PageCount = 200,
                    PublishDate = "12.06.2001 00:00:00"
                },
                new BooksViewModel
                {
                    Title = "Herland",
                    Genre = "Science Fiction",
                    Author = "John SteinBack",
                    PageCount = 300,
                    PublishDate = "15.07.2004 00:00:00"
                },
                new BooksViewModel
                {
                    Title = "Dune",
                    Genre = "Science Fiction",
                    Author = "George Orwell",
                    PageCount = 400,
                    PublishDate = "23.05.2010 00:00:00"
                }
            }, options => options.WithStrictOrdering());
        }

    }
}
