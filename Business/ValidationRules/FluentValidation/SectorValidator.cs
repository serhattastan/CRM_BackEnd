using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SectorValidator : AbstractValidator<Sector>
    {
        public SectorValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
