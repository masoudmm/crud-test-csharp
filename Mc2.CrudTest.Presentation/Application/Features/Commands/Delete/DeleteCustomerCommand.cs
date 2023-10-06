using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;

public record DeleteCustomerCommand(int Id) : IRequest<int>;

public class DeleteCustomerCommanddHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private int Id;

    public DeleteCustomerCommanddHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(DeleteCustomerCommand request, 
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        Id = request.Id;

        var customerToDelete = await _dbContext
            .Customers
            .FirstOrDefaultAsync(c => c.Id == Id, cancellationToken);

        if (customerToDelete is null)
        {
            throw new DbEntityNotFoundException("Customer", Id);
        }

        customerToDelete.Delete();

        _dbContext.Customers.Remove(customerToDelete);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return customerToDelete.Id;
    }
}

