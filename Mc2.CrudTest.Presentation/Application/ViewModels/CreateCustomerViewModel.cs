using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Application.ViewModels;

public class CreateCustomerViewModel
{
    [Required]
    [StringLength(maximumLength: 30, MinimumLength = 2)]
    public string Firstname { get; set; }

    [Required]
    [StringLength(maximumLength: 60, MinimumLength = 2)]
    public string Lastname { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }


    [Required]
    [StringLength(maximumLength: 15, MinimumLength = 4)]
    public string PhoneNumber { get; set; }


    [Required]
    [EmailAddress]
    [StringLength(maximumLength: 60, MinimumLength = 6)]
    public string Email { get; set; }


    [Required]
    [StringLength(maximumLength: 20, MinimumLength = 6)]
    public string BankAccountNumber { get; set; }
}
