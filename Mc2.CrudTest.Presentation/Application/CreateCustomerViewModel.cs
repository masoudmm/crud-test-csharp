using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Application
{
    public class CreateCustomerViewModel
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        
        
        [Required]
        [StringLength(7)]
        public string PhoneNumber { get; set; }
        
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        
        [Required]
        public string BankAccountNumber { get; set; }
    }
}
