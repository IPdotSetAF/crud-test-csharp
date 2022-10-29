namespace CrudTest.Core.Contracts.DTOs.Customer
{
    public class CustomerUpdateDTO
    {
        public string PhoneNumber { get; set; }
        public ulong BankAccountNumber { get; set; }
        public string Email { get; set; }
    }
}
