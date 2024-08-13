using BookStoreWebApi.Application.GenreOperations.Queries.GetGenre;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class GetGenreValidator:AbstractValidator<GetGenreQuery>
    {
        public GetGenreValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}
