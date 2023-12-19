using Application.Extentions;
using CustomerCrud.Infrastructure.Extentions;
using CustomerCrud.Server.Components;
using CustomerCrud.Server.Extentions;
using CustomerCrud.Server.Filters;
using MudBlazor.Services;
using System.Diagnostics.Metrics;

namespace CustomerCrud.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddControllersWithViews();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        
        builder.Services.AddMudServices();

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7202") });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseAntiforgery();
        app.UseExceptionFilter();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client.Program).Assembly);

        app.MapControllers();

        app.MapCustomerEndPoints();

        app.Run();
    }
}
