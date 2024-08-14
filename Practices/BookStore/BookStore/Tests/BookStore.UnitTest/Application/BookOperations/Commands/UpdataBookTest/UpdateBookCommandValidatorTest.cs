using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.ValidationRules;
using FluentAssertions;
using Xunit;
using static BookStoreWebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace BookStore.UnitTest.Application.BookOperations.Commands.UpdataBookTest
{
    public class UpdateBookCommandValidatorTest
    {

        private readonly UpdateBookValidator _validator;

        public UpdateBookCommandValidatorTest()
        {
            _validator = new();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenIdIsInvalid_Validator_ShouldBeReturnError(int bookId)
        {
            //arrange
            UpdateBookCommand command = new(null);
            var model = new UpdateBookViewModel() { Title = "Updated Book", GenreId = 2, AuthorId = 1 };
            command.BookId = bookId;
            command.Model = model;

            //act
            var action = FluentActions.Invoking(() => _validator.Validate(command)).Invoke();

            //assert
            action.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("ab", 0, 0)]
        [InlineData("ab", 1, 0)]
        [InlineData("ab", 0, 1)]
        [InlineData("abcd", 0, 1)]
        [InlineData("abcd", 1, 0)]
        [InlineData(" ", 1, 1)]
        [InlineData(" ", 0, 0)]
        public void WhenInputsAreInvalid_Validator_ShouldBeReturnError(string title, int genreId, int authorId)
        {
            //arrange
            UpdateBookCommand command = new(null);
            var model = new UpdateBookViewModel()
            {
                Title = title,
                GenreId = genreId,
                AuthorId = authorId
            };
            command.Model = model;
            command.BookId = 1;

            //act
            var action = FluentActions.Invoking(() => _validator.Validate(command)).Invoke();

            //assert

            action.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInputsAreValid_Validator_ShouldNotBeError()
        {
            //arrange
            UpdateBookCommand command = new(null);
            var model = new UpdateBookViewModel()
            {
                Id=1,
                AuthorId = 1,
                GenreId = 2,
                Title = "Right decision",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            command.Model = model;

            //act
            var action = FluentActions.Invoking(() => _validator.Validate(command)).Invoke();

            //assert
            action.Errors.Count.Should().Be(0);

        }
    }
}
