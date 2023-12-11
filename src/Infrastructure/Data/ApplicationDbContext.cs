using CustomerCrud.Application.Common.Interfaces;
using CustomerCrud.Infrastructure.Data.Interceptor;
using CustomerCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerCrud.Infrastructure.Data;

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