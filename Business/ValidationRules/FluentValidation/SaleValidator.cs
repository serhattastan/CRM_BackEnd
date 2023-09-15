using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.Date).NotEmpty();
        }
    }
}
