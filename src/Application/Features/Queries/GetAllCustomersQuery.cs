using AutoMapper;
using CustomerCrud.Application.Common.Interfaces;
using CustomerCrud.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerCrud.Application.Features.Queries;

public class GetAllCustomersQuery : IRequest<IReadOnlyList<CustomerDto>> { };

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<CustomerDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(IApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CustomerDto>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _dbContext
            .Customers
            .ToListAsync();

        var customerDtos = _mapper.Map<IReadOnlyList<CustomerDto>>(customers);

        return customerDtos;
    }
}
