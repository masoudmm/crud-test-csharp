using FluentValidation;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;
public class EditCustomerCommandValidator : AbstractValidator<EditCustomerCommand>
{
    public EditCustomerCommandValidator()
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
            .NotEmpty();

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
