using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.ValidationRules;
using FluentAssertions;
using Xunit;
using static BookStoreWebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace BookStoreWebApi.Application.BookOperations.Commands.CreateBookTest
{
    public class CreateBookCommandValidatorTest
    {
        [Theory]
        [InlineData("Lorf of the Rings", 0, 0)]
        [InlineData("Lorf of the Rings", 0, 1)]
        [InlineData("Lorf of the Rings", 100, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 100, 0)]
        [InlineData("Lord", 0, 1)]
        [InlineData(" ", 100, 1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {

            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new CreateBookModel() { PublishDate = DateTime.Now.Date.AddYears(-1), PageCount = pageCount, Title = title, GenreId = genreId, };

            //act
            CreateBookValidator validator = new();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new CreateBookModel()
            {
                PublishDate = DateTime.Now.Date,
                PageCount = 100,
                Title = "Lord of The Rings",
                GenreId = 1,
            };

            //act
            CreateBookValidator validator = new();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateBookCommand command = new(null, null);
            command.Model = new CreateBookModel()
            {
                PublishDate = DateTime.Now.Date.AddYears(-1),
                PageCount = 100,
                Title = "Lord of The Rings",
                GenreId = 1,
            };

            //act
            CreateBookValidator validator = new();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count().Should().Be(0);
        }
    }
}
