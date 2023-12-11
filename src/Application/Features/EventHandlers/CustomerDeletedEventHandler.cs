using CustomerCrud.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCrud.Application.Features.EventHandlers;

public class CustomerDeletedEventHandler : INotificationHandler<CustomerDeletedEvent>
{
    private readonly ILogger<CustomerDeletedEventHandler> _logger;

    public CustomerDeletedEventHandler(ILogger<CustomerDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CustomerDeletedEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Customer Deleted!");
    }
}
