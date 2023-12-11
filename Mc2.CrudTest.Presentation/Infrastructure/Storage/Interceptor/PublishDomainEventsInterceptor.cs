using Shared.Event;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Storage.Interceptor;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IMediator _mediator;

    public PublishDomainEventsInterceptor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        IEnumerable<IPublishesDomainEvents> entities = eventData.Context.ChangeTracker
            .Entries<IPublishesDomainEvents>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        List<DomainEvent> domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        foreach (DomainEvent domainEvent in domainEvents)
        {
            await _mediator
                .Publish(domainEvent)
                .ConfigureAwait(false);
        }

        return await base.SavingChangesAsync(eventData!,
            result,
            cancellationToken);
    }
}
