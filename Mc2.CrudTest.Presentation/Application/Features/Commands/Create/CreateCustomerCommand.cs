using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Create
{
    public record CreateCustomerCommand(string Firstname,
            string Lastname,
            DateTime DateOfBirth,
            string PhoneNumber,
            string Email,
            string BankAccountNumber) : IRequest<CustomerDto>;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var newCustomer = Customer.Create(request.Firstname,
            request.Lastname,
            request.DateOfBirth,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber);

            //ToDo: Save new customer to database

            return _mapper.Map<CustomerDto>(newCustomer);
        }
    }
}
