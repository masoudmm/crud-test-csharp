using Shared.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.EventHandlers;

public class CustomerEditedEventHandler : INotificationHandler<CustomerEditedEvent>
{
    private readonly ILogger<CustomerEditedEventHandler> _logger;

    public CustomerEditedEventHandler(ILogger<CustomerEditedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CustomerEditedEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Customer Edited");
    }
}
