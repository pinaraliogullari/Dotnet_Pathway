using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
