using AutoMapper;
using BookStore.UnitTest.TestSetup;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using Xunit;
using static BookStoreWebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace BookStore.UnitTest.Application.BookOperations.Commands.CreateBookTest
{
    //IClassFicture, xunitten gelen bir interface
    public class CreateBookCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1996, 08, 18), AuthorId = 1, GenreId = 2 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new(_context, _mapper);
            command.Model = new CreateBookModel { Title = book.Title };

            //act && assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShoulBeCreated()
        {
            //arrange
            CreateBookCommand command = new(_context, _mapper);
            CreateBookModel model = new() { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddDays(-2), GenreId = 2 };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            book.PublishDate.Should().Be(model.PublishDate);
        }
    }
}
