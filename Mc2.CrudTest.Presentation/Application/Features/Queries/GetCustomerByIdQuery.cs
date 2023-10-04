using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerDto> { };
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(
        IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        //TODO: Get customers from database

        var customer = Customer.Create("FirstName",
        "Lastname",
        DateTime.UtcNow,
        "PhoneNumber",
        "Email",
        "BankAccountNumber");

        return _mapper.Map<CustomerDto>(customer);
    }
}
