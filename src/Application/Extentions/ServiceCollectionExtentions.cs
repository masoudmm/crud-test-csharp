﻿using FluentValidation;
using CustomerCrud.Application.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;

        AddAutoMapper(services);

        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(applicationAssembly);
            config.AddOpenBehavior(typeof(CustomerValidationBehavior<,>));
        });

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;
        services.AddAutoMapper(applicationAssembly);

        return services;
    }
}
