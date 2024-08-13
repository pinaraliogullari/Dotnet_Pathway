using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthor;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class GetAuthorValidator:AbstractValidator<GetAuthorQuery>
    {
        public GetAuthorValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}
