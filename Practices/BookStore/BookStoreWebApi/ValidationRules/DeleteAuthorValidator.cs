using BookStoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}
