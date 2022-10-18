using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Customer
{
    public class CustomerUpdateDTO
    {
        public ulong PhoneNumber { get; set; }
        public ulong BankAccountNumber { get; set; }
    }
}
