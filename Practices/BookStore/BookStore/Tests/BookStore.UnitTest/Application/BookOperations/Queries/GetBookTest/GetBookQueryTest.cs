using AutoMapper;
using BookStore.UnitTest.TestSetup;
using BookStoreWebApi.Application.BookOperations.Queires.GetBook;
using BookStoreWebApi.DbOperations;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BookStore.UnitTest.Application.BookOperations.Queries.GetBookTest
{
    public class GetBookQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookQueryTest(CommonTextFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]

        public void WhenIdIsNotFound_InvalidOperationExceptions_ShouldBeReturnError()
        {
            //arrange
            GetBookQuery query = new(_context, _mapper);
            int bookId = 28;
            query.BookId = bookId;

            //act
            var result = FluentActions.Invoking(() => query.Handle())

            //assert
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");

        }

        [Fact]

        public void WhenIdIsValid_Book_ShouldNotBeReturnError()
        {
            //arrange
            GetBookQuery query = new(_context, _mapper);
            int bookId = 1; 
            query.BookId = bookId;

            var book= _context.Books.Include(x=>x.Author).Include(x=>x.Genre).SingleOrDefault(x=>x.Id== bookId);

            //act
           var result=  FluentActions.Invoking(() => query.Handle()).Invoke();

            //assert
            result.Should().NotBeNull();
            result.Title.Should().Be(book.Title);
            result.PageCount.Should().Be(book.PageCount);
            result.Genre.Should().Be(book.Genre.Name);
            result.Author.Should().Be(book.Author.FirstName + " " + book.Author.LastName);
            result.PublishDate.Should().Be(book.PublishDate.ToString("dd/MM/yyyy 00:00:00"));
        }
    }
}
