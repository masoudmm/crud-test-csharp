using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Infrastructure.Storage.Interceptor;
using Mc2.CrudTest.Presentation.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Infrastructure.Storage;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly PublishDomainEventsInterceptor _dispatchDomainEventsInterceptor;

    public ApplicationDbContext(DbContextOptions options,
        PublishDomainEventsInterceptor dispatchDomainEventsInterceptor)
        : base(options)
    {
        _dispatchDomainEventsInterceptor = dispatchDomainEventsInterceptor;
    }

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dispatchDomainEventsInterceptor);
    }
}