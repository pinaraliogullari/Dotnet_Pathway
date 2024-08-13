using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x=>x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now.Date).NotEmpty();
        }
    }
}
