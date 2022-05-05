using FluentValidation;
using Bookstore.Api.BindingModels;

namespace Bookstore.Api.Validation;
    public class UpdateBookPriceValidator : AbstractValidator<UpdateBookPrice>
    {
        public UpdateBookPriceValidator()
        {
            RuleFor(x=>x.Price).NotEmpty();
        }
    }
