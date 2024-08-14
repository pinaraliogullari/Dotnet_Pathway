using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.ValidationRules;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTest.Application.BookOperations.Commands.DeleteBookTest
{
    public class DeleteBookCommandValidatorTest
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void WhenGivenIdIsNotValid_Validator_ShouldBeReturnError(int bookId)
        {
            DeleteBookCommand command = new(null);
            command.BookId = bookId;

            DeleteBookValidator validator = new();
            var action = FluentActions.Invoking(() => validator.Validate(command)).Invoke();

            action.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenGivenIdIsValid_Validator_ShouldBeNotReturnError() 
        {
            DeleteBookCommand command = new(null);
            command.BookId = 1;

            DeleteBookValidator validator = new();
            var action= FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            action.Errors.Count().Should().Be(0);
        }
    }
}
