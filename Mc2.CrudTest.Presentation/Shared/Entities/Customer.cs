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

    public void Edit(int id, 
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        //TODO: Add edit event
    }

    public void Delete(int id)
    {
        //TODO: Add delete event
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

        //TODO: Add create event

        return customer;
    }
}
