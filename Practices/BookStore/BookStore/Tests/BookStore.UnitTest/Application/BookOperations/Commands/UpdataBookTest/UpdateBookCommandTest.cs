using BookStore.UnitTest.TestSetup;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using Xunit;
using static BookStoreWebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace BookStore.UnitTest.Application.BookOperations.Commands.UpdataBookTest
{
    public class UpdateBookCommandTest:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandTest(CommonTextFixture fixture)
        {
            _context=fixture.Context;
        }

        [Fact]
        public void WhenBookIdIsNotFound_InvalidOperationExceptions_ShoudBeReturn()
        {
            //arrange
            UpdateBookCommand command = new(_context);
            int bookId = 28;
            command.BookId = bookId;

            //act
            var action= FluentActions.Invoking(() => command.Handle());

            //assert
         
            action.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap bulunamadı");


        }

        [Fact]
        public void WhenGivenInputAreValid_Book_ShouldBeUpdated()
        {
            //arrange
            UpdateBookCommand command = new(_context);
            var book = new Book() { Title = "Test Book", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-2), GenreId = 1 ,AuthorId=1};

            _context.Books.Add(book);
            _context.SaveChanges();

            command.BookId=book.Id;
            var model= new UpdateBookViewModel() { PageCount=200,PublishDate=DateTime.Now.Date.AddYears(-3),Title="Updated Book"};
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var updatedBook=_context.Books.SingleOrDefault(x=>x.Id==book.Id);
            updatedBook.Should().NotBeNull();
            updatedBook.AuthorId.Should().Be(book.AuthorId);
            updatedBook.GenreId.Should().Be(book.GenreId);
            updatedBook.PageCount.Should().Be(book.PageCount);
            updatedBook.PublishDate.Should().Be(book.PublishDate);
            updatedBook.Title.Should().Be(book.Title);
        }
    }
}
