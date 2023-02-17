using ARTCC.Core.Shared.Models;
using FluentValidation;

namespace ARTCC.Core.API.Validators;

public class FaqValidator : AbstractValidator<Faq>
{
    public FaqValidator()
    {
        RuleFor(x => x.Fact).NotEmpty();
        RuleFor(x => x.Answer).NotEmpty();
    }
}
