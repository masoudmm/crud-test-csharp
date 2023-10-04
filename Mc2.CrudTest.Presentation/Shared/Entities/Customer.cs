namespace Mc2.CrudTest.Presentation.Shared.Entities;

public class Customer
{
    public int Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    private Customer()
    {
    }

    public void Edit(string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        //TODO: Add edit event
    }

    public static Customer Create(string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        var customer = new Customer()
        {
            Firstname = firstname,
            Lastname = lastname,
            DateOfBirth = dateOfBirth,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber
        };

        //TODO: Add create event

        return customer;
    }
}
