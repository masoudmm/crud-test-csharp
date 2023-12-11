using CustomerCrud.Application.Common.Interfaces;
using CustomerCrud.Infrastructure.Data;
using CustomerCrud.Infrastructure.Data.Interceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCrud.Infrastructure.Extentions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"), builder =>
            {
                builder.MigrationsAssembly(typeof(ServiceCollectionExtention).Assembly.FullName);
                builder.EnableRetryOnFailure();
            }));

        return services;
    }
}
