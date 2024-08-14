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
            result.Should().HaveCount(1);
            //result[0].Title.Should().Be("Lean Startup");
            //result[0].Genre.Should().Be("Personel Growth");
            //result[0].Author.Should().Be("John Steinback");
            //result[0].PageCount.Should().Be(200);
            //result[0].PublishDate.Should().Be("12.06.2001 00:00:00");

            //result[1].Title.Should().Be("Herland");
            //result[1].Genre.Should().Be("Science Fiction");
            //result[1].Author.Should().Be("Charlotte Perkins Gilman");
            //result[1].PageCount.Should().Be(250);
            //result[1].PublishDate.Should().Be("23.05.2010 00:00:00");

            //result[2].Title.Should().Be("Dune");
            //result[2].Genre.Should().Be("Science Fiction");
            //result[2].Author.Should().Be("Frank Herbert");
            //result[2].PageCount.Should().Be(540);
            //result[2].PublishDate.Should().Be("21.12.2002 00:00:00");
            result.Should().BeEquivalentTo(new List<BooksViewModel>
            {
                new BooksViewModel
                {
                    Title = "Lean Startup",
                    //Genre = "Personel Growth",
                    Genre="BookStoreWebApi.Entities.Genre",
                    Author = "John SteinBack",
                    PageCount = 200,
                    PublishDate = "12.06.2001 00:00:00"
                },
                new BooksViewModel
                {
                    Title = "Herland",
                    //Genre = "Science Fiction",
                      Genre="BookStoreWebApi.Entities.Genre",
                    Author = "John Steinback",
                    PageCount = 300,
                    PublishDate = "15.07.2004 00:00:00"
                },
                new BooksViewModel
                {
                    Title = "Dune",
                    //Genre = "Science Fiction",
                      Genre="BookStoreWebApi.Entities.Genre",
                    Author = "George Orwell",
                    PageCount = 400,
                    PublishDate = "23.05.2010 00:00:00"
                }
            }, options => options.WithStrictOrdering());
        }

    }
}
