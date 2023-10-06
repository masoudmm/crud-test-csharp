using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Application.Exceptions;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;

public record EditCustomerCommand(int Id,
        string Firstname,
        string Lastname,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        string BankAccountNumber) : IRequest<CustomerDto>;

public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, CustomerDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public EditCustomerCommandHandler(IApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var customerToEdit = await _dbContext
            .Customers
            .FirstOrDefaultAsync(c => c.Id == request.Id,
            cancellationToken);

        if (customerToEdit is null)
        {
            throw new DbEntityNotFoundException("Customer",
            request.Id);
        }

        var sameCustomersAfterEdit = await _dbContext
            .Customers
            .FirstOrDefaultAsync(c => 
            (c.Id != customerToEdit.Id) &&
                ((c.Email == request.Email) ||
                    (c.Firstname == request.Firstname &&
                    c.Lastname == request.Lastname &&
                    c.DateOfBirth == request.DateOfBirth)),
            cancellationToken);

        if (sameCustomersAfterEdit is not null)
        {
            throw new DbEntityAlreadyExistException("Customer",
                $"With: \"{request.Firstname} {request.Lastname} {request.DateOfBirth}\" combination OR Email: {request.Email}");
        }

        customerToEdit.Edit(request.Id,
        request.Firstname,
        request.Lastname,
        request.DateOfBirth,
        request.PhoneNumber,
        request.Email,
        request.BankAccountNumber);

        var dbCustomer = _dbContext
            .Customers
            .Update(customerToEdit);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(customerToEdit);
    }
}

