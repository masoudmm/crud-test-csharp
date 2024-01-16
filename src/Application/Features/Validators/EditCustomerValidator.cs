using AutoMapper;
using CustomerCrud.Application.Features.Commands.Edit;
using CustomerCrud.Application.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace CustomerCrud.Application.Validators;

public class EditCustomerValidator(EditCustomerCommandValidator commandValidator,
    IMapper mapper) : AbstractValidator<EditCustomerViewModel>
{
    private readonly EditCustomerCommandValidator _commandValidator = commandValidator;
    private readonly IMapper _mapper = mapper;

    public override ValidationResult Validate(ValidationContext<EditCustomerViewModel> context)
        => _commandValidator.Validate(_mapper.Map<EditCustomerCommand>(context));
}
