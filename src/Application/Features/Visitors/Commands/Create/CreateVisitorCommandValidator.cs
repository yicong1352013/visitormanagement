// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Visitors.Commands.Create;

    public class CreateVisitorCommandValidator : AbstractValidator<CreateVisitorCommand>
    {
        public CreateVisitorCommandValidator()
        {
        RuleFor(v => v.Name).MaximumLength(256).NotEmpty();
        RuleFor(v => v.PassCode).MaximumLength(256).NotEmpty();
        RuleFor(v => v.Email).MaximumLength(256).NotEmpty();
        RuleFor(v => v.PhoneNumber).MaximumLength(256).NotEmpty();
        RuleFor(v => v.Purpose).MaximumLength(256).NotEmpty();
        RuleFor(v => v.EmployeeId).NotNull();
        RuleFor(v => v.Avatar).NotNull();
        RuleFor(v => v.TripCode).NotNull();
        RuleFor(v => v.HealthCode).NotNull();
        RuleFor(v => v.PrivacyPolicy).Equal(true);
        RuleFor(v => v.Promise).Equal(true);
    }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
     {
        var result = await ValidateAsync(ValidationContext<CreateVisitorCommand>.CreateWithOptions((CreateVisitorCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
     };
    }

