using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;

public record EditCustomerCommand(string Firstname,
        string Lastname,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        string BankAccountNumber) : IRequest<CustomerDto>;

public class UpdateCustomerCommandHandler : IRequestHandler<EditCustomerCommand, CustomerDto>
{
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var customerToEdit = Customer.Create(request.Firstname + " edited!",
        request.Lastname + " edited!",
        request.DateOfBirth.AddDays(1),
        request.PhoneNumber + " edited!",
        request.Email + " edited!",
        request.BankAccountNumber + " edited!");

        //TODO: Update customer in database

        return _mapper.Map<CustomerDto>(customerToEdit);
    }
}

