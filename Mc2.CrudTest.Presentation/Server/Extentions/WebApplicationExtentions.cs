using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Application.Features.Commands.Create;
using Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;
using Mc2.CrudTest.Presentation.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Mc2.CrudTest.Presentation.Server.Extentions;

public static class WebApplicationExtentions
{
    public static void MapCustomerEndPoints(this WebApplication app)
    {
        app.MapGet("/api/Customers", (ISender sender,
                CancellationToken ct) =>
            sender.Send(new GetAllCustomersQuery(), ct))
                .Produces<CustomerDto>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapGet("/api/Customers/{id:int}", (ISender sender,
            [FromRoute] int id,
            CancellationToken ct) => sender.Send(new GetCustomerByIdQuery(id), ct))
        .Produces<CustomerDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPost("/api/Customers/Create", (ISender sender,
            CreateCustomerCommand command,
            CancellationToken ct) =>
        sender.Send(command, ct))
        .Produces<CustomerDto>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPut("/api/Customers/Edit", (ISender sender,
            EditCustomerCommand command,
            CancellationToken ct) =>
        sender.Send(command, ct))
        .Produces<CustomerDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapDelete("/api/Customers/Delete/{id:int}", (ISender sender,
            [FromRoute] int id,
            CancellationToken ct) =>
        sender.Send(new DeleteCustomerCommand(id), ct))
        .Produces<int>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}

