namespace Mc2.CrudTest.Presentation.Shared.Event;

public interface IPublishesDomainEvents
{
    ICollection<DomainEvent> DomainEvents { get; }

    void AddDomainEvent(DomainEvent domainEvent);
}