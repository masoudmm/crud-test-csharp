using Application.Dtos;
using Application.Features.Commands.Create;
using Application.Features.Commands.Edit;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Extentions;

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

