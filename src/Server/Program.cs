using Application.Extentions;
using CustomerCrud.Client.Components;
using CustomerCrud.Infrastructure.Extentions;
using CustomerCrud.Server.Extentions;
using CustomerCrud.Server.Filters;
using MudBlazor.Services;

namespace CustomerCrud.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddControllersWithViews();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        
        builder.Services.AddMudServices();

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7202") });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseAntiforgery();
        
        app.UseExceptionFilter();

        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode();

        app.MapControllers();

        app.MapCustomerEndPoints();

        app.Run();
    }
}
