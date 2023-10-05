using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Queries;

public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto>;
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IMapper _mapper;
    private int Id;

    public GetCustomerByIdQueryHandler(
        IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        Id = request.Id;

        //TODO: Get customers from database

        var customer = Customer.Create($"FirstName {Id}",
        $"Lastname {Id}",
        DateTime.UtcNow.AddDays(Id),
        $"Phone {Id}",
        $"Email@Email {Id}",
        $"BankAccountNumber {Id}",
        Id);

        return _mapper.Map<CustomerDto>(customer);
    }
}
