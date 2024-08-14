using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MaximumLength(4);
        }
    }
}
