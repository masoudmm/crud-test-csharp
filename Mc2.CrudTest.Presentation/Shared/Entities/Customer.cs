using System.ComponentModel.DataAnnotations.Schema;
using Shared.Event;

namespace Shared.Entities;

public record CustomerCreatedEvent(Customer NewCustomer) : DomainEvent;
public record CustomerEditedEvent(Customer NewCustomer) : DomainEvent;
public record CustomerDeletedEvent(int deletedCustomerId) : DomainEvent;

public class Customer : IPublishesDomainEvents
{
    public int Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    private readonly List<DomainEvent> _domainEvents = new();

    private Customer()
    {
    }

    public void Edit(int id,
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

        AddDomainEvent(new CustomerEditedEvent(this));
    }

    public void Delete()
    {
        AddDomainEvent(new CustomerDeletedEvent(Id));
    }

    public static Customer Create(string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber,
        int id = 0)
    {
        var customer = new Customer()
        {
            Id = id,
            Firstname = firstname,
            Lastname = lastname,
            DateOfBirth = dateOfBirth,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber
        };

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        return customer;
    }

    [NotMapped]
    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
