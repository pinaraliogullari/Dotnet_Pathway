using BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Model.FirstName).MinimumLength(3).When(x => x.Model.FirstName.Trim() != string.Empty);
            RuleFor(x => x.Model.LastName).MinimumLength(3).When(x => x.Model.FirstName.Trim() != string.Empty);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
