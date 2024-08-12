using BookStoreWebApi.BookOperations.UpdateBook;
using FluentValidation;

namespace BookStoreWebApi.ValidationRules
{
    public class UpdateBookValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PageCount).GreaterThan(50);
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
        }
    }
}
