using BookStoreWebApi.Application.BookOperations.Queires.GetBook;
using BookStoreWebApi.ValidationRules;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTest.Application.BookOperations.Queries.GetBookTest
{
    public class GetBookQueryValidatorTest
    {
        private readonly GetBookValidator _validator;

        public GetBookQueryValidatorTest()
        {
            _validator = new();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]

        public void WhenIdIsNotValid_Validator_ShouldBeReturnError(int bookId)
        {
            //arrange
            GetBookQuery query = new(null, null);
            query.BookId = bookId;

            //act
            var result = FluentActions.Invoking(() => _validator.Validate(query)).Invoke();
            //veya
            //var result= _validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenIdIsValid_Validator_ShouldBeNotReturnError()
        {
            //arrange
            GetBookQuery query = new(null, null);
            query.BookId = 2;

            //act
            var result = FluentActions.Invoking(() => _validator.Validate(query)).Invoke();
            //veya
            //var result= _validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
