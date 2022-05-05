using Bookstore.Api.BindingModels;
using FluentValidation;

namespace Bookstore.Api.Validation
{
    public class AddBookValidator : AbstractValidator<AddBook>
    {
        public AddBookValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.Price).NotEmpty();
            RuleFor(x=>x.PublisherId).NotEmpty();
        }
    }
}