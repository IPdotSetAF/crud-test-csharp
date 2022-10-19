using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Customer
{
    public class CustomerUpdateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
        public ulong PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Banck account is required.")]
        public ulong BankAccountNumber { get; set; }
    }
}
