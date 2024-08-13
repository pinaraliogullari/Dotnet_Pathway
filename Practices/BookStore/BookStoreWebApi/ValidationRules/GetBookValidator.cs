using BookStoreWebApi.Application.BookOperations.Queires.GetBook;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class GetBookValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
