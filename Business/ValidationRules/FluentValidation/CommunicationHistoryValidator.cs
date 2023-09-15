using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CommunicationHistoryValidator : AbstractValidator<CommunicationHistory>
    {
        public CommunicationHistoryValidator()
        {
            RuleFor(p => p.Date).NotEmpty();
            RuleFor(p => p.CommunicationTypeId).NotEmpty();
            RuleFor(p => p.OfferId).NotEmpty();
            RuleFor(p => p.ResultId).NotEmpty();
        }
    }
}
