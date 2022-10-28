using System.ComponentModel.DataAnnotations;

namespace CrudTest.Core.Contracts.DTOs.Customer
{
    public class CustomerUpdateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
        public ulong PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Banck account is required.")]
        public ulong BankAccountNumber { get; set; }
    }
}
