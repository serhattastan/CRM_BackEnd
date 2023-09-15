using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Stock).NotEmpty();
            RuleFor(p => p.Stock).GreaterThan(-1);
            RuleFor(p => p.CategoryId).NotEmpty();

        }
    }
}
