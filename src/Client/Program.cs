using CustomerCrud.Application.Features.Commands.Edit;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Application.Extentions;
using System.Reflection;
using FluentValidation;

namespace CustomerCrud.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddMudServices();

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddApplicationValidators();
        builder.Services.AddApplicationAutoMapper();

        await builder.Build().RunAsync();
    }
}