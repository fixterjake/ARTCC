using ARTCC.Core.Shared.Models;
using FluentValidation;

namespace ARTCC.Core.API.Validators;

public class EventPositionValidator : AbstractValidator<EventPosition>
{
    public EventPositionValidator()
    {
        RuleFor(x => x.EventId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MinRating).NotEmpty();
    }
}
