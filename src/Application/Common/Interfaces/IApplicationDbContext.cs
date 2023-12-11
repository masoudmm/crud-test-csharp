using CustomerCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerCrud.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
