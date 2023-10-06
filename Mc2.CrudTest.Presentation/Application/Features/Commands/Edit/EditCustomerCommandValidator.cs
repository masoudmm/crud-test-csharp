﻿using FluentValidation;
using Mc2.CrudTest.Presentation.Application.Common;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;

public class EditCustomerCommandValidator : AbstractValidator<EditCustomerCommand>
{
    public EditCustomerCommandValidator()
    {
        RuleFor(c => c.Firstname)
            .NotNull()
            .NotEmpty()
            .Length(3, 30);

        RuleFor(c => c.Lastname)
            .NotNull()
            .NotEmpty()
            .Length(3, 60);

        RuleFor(c => c.DateOfBirth)
            .NotNull()
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow.AddYears(-100));

        RuleFor(c => c.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .Length(4, 15);

        RuleFor(c => c.PhoneNumber)
            .Must((phoneNumber) =>
            {
                //TODO: Check if it is the right way...
                var result = PhoneNumberUtil.IsViablePhoneNumber(PhoneNumberUtil.ExtractPossibleNumber(phoneNumber));
                return result;
            })
            .WithName("PhoneNumber is invalid");

        RuleFor(c => c.Email)
            .NotNull()
            .NotEmpty()
            .Length(6, 60)
            .EmailAddress();

        RuleFor(c => c.BankAccountNumber)
            .NotNull()
            .NotEmpty()
            .Length(6, 20);

        RuleFor(c => c.BankAccountNumber)
            .Must(ValidationHelpers.DutchBankAccountNumberRegx().IsMatch)
            .WithName("BankAccountNumber format is invalid");
    }
}