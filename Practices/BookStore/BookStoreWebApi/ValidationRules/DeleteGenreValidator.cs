using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
