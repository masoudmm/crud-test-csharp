using AutoMapper;
using CustomerCrud.Application.Common.Interfaces;
using CustomerCrud.Application.Dtos;
using CustomerCrud.Application.Exceptions;
using CustomerCrud.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerCrud.Application.Features.Commands.Create;

public record CreateCustomerCommand(string Firstname,
        string Lastname,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        string BankAccountNumber) : IRequest<CustomerDto>;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public CreateCustomerCommandHandler(IMapper mapper,
        IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
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

        var sameCustomers = await _dbContext
            .Customers
            .FirstOrDefaultAsync(c => 
                (c.Email == newCustomer.Email) ||
                (c.Firstname == newCustomer.Firstname && 
                c.Lastname == newCustomer.Lastname &&
                c.DateOfBirth == newCustomer.DateOfBirth),
            cancellationToken);

        if (sameCustomers is not null)
        {
            throw new DbEntityAlreadyExistException("Customer",
            $"With: \"{newCustomer.Firstname} {newCustomer.Lastname} {newCustomer.DateOfBirth}\" combination OR Email: {newCustomer.Email}");
        }

        var createdCustomer = await _dbContext.Customers.AddAsync(newCustomer,
            cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(createdCustomer.Entity);
    }
}
