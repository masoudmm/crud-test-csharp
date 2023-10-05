using Mc2.CrudTest.Presentation.Application;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Application.Features.Commands.Create;
using Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;
using Mc2.CrudTest.Presentation.Application.Features.Queries;
using Mc2.CrudTest.Presentation.Server;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddApplication();

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

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseExceptionFilter();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.MapGet("/api/Test", () => "ooookokokokokokkkkkkkkkkkkkkkkkkkkkkkkk");

            app.MapGet("/api/Customers", (ISender sender,
                CancellationToken ct) => sender.Send(new GetAllCustomersQuery(), ct))
            .Produces<CustomerDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

            app.MapGet("/api/Customers/{id:int}", (ISender sender,
                [FromRoute] int id,
                CancellationToken ct) => sender.Send(new GetCustomerByIdQuery(id), ct))
            .Produces<CustomerDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

            app.MapPost("/api/Customers/Create", (ISender sender,
                CreateCustomerCommand command,
                CancellationToken ct) => sender.Send(command, ct))
            .Produces<CustomerDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

            app.MapPut("/api/Customers/Edit", (ISender sender,
                EditCustomerCommand command,
                CancellationToken ct) => sender.Send(command, ct))
            .Produces<CustomerDto>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError);


            app.MapDelete("/api/Customers/Delete/{id:int}", (ISender sender,
                [FromRoute] int id,
                CancellationToken ct) => sender.Send(new DeleteCustomerCommand(id), ct))
            .Produces<int>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

            app.Run();
        }
    }
}