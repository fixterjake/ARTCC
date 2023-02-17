﻿using ARTCC.Core.Shared.Models;
using FluentValidation;

namespace ARTCC.Core.API.Validators;

public class EventValidator : AbstractValidator<Event>
{
    public EventValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Host).NotEmpty();
    }
}
