using Bookstore.Api.BindingModels;
using FluentValidation;

namespace Bookstore.Api.Validation
{
    public class EditBookValidator : AbstractValidator<EditBook>
    {
        public EditBookValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.Price).NotEmpty();
            RuleFor(x=>x.PublisherId).NotEmpty();
        }
    }
    
}