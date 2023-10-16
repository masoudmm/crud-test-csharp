using Mc2.CrudTest.Presentation.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
