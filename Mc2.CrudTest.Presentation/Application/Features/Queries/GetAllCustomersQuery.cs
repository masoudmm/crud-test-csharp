using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Queries;

public class GetAllCustomersQuery : IRequest<IReadOnlyList<CustomerDto>> { };
public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<CustomerDto>>
{
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(
        IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CustomerDto>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        //TODO: Get customers from database

        return Enumerable.Range(1, 5).Select(index => Customer.Create
        (
            $"Firstname {index}",
            $"Lastname {index}",
            DateTime.UtcNow.AddDays(index),
            $"Phone {index}",
            $"Email@email {index}",
            $"BankAccountNumber {index}",
            index
        ))
            .AsQueryable()
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .ToList();
    }
}
