using ARTCC.Core.Shared.Models;
using FluentValidation;

namespace ARTCC.Core.API.Validators;

public class AirportValidator : AbstractValidator<Airport>
{
    public AirportValidator()
    {
        RuleFor(x => x.Icao).NotEmpty().Length(4);
        RuleFor(x => x.Name).NotEmpty();
    }
}
