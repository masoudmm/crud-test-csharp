using FluentValidation;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        //TODO: Add real validation rules

        RuleFor(m => m.Firstname)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.Lastname)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.DateOfBirth)
            .NotNull()
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow.AddYears(-100));

        RuleFor(m => m.PhoneNumber)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.Email)
            .NotNull()
            .NotEmpty();

        RuleFor(m => m.BankAccountNumber)
            .NotNull()
            .NotEmpty();
    }
}
