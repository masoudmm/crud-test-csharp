using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Presentation.Application.Features.EventHandlers;

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
