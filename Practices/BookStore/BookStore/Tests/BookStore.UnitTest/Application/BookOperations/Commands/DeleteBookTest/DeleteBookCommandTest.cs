using BookStore.UnitTest.TestSetup;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.DbOperations;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTest.Application.BookOperations.Commands.DeleteBookTest
{
    public class DeleteBookCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandTest(CommonTextFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenBookIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
         
            DeleteBookCommand command = new(_context);
            command.BookId = 22;

            //act 
            var action = FluentActions.Invoking(() => command.Handle());

            //assert
            action.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı");

        }

        [Fact]

        public void WhenBookIdIsValid_Book_ShouldBeDeleted()
        {
            //arrange
           DeleteBookCommand command= new(_context);
            command.BookId = 2;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book= _context.Books.SingleOrDefault(x=>x.Id==command.BookId);
            book.Should().BeNull();
        }
    }
}
