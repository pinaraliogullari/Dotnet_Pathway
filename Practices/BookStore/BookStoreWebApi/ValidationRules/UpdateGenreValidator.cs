using BookStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}
