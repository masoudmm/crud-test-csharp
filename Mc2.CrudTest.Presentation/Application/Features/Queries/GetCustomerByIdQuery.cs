﻿using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Application.Features.Queries;

public record GetCustomerByIdQuery(int Id) : IRequest<CustomerDto>;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private int Id;

    public GetCustomerByIdQueryHandler(IApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        Id = request.Id;

        var customer = await _dbContext
            .Customers
            .FirstOrDefaultAsync(c => c.Id == Id,
            cancellationToken);

        if (customer is not null)
        {
            return _mapper.Map<CustomerDto>(customer);
        }

        throw new DbEntityNotFoundException("Customer", Id);
    }
}