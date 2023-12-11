using CustomerCrud.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCrud.Application.Features.EventHandlers;

public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CustomerCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Customer created");
    }
}
