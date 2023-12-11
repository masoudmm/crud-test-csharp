namespace CustomerCrud.Domain.Event;

public interface IPublishesDomainEvents
{
    ICollection<DomainEvent> DomainEvents { get; }

    void AddDomainEvent(DomainEvent domainEvent);
}