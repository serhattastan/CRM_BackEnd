using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OfferValidator : AbstractValidator<Offer>
    {
        public OfferValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.EndDate).GreaterThan(p => p.StartDate);
        }
    }
}
