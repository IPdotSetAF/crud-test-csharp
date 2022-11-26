namespace CrudTest.Bussiness.Contracts.DTOs.Customer
{
    public class CustomerUpdateDTO
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public ulong BankAccountNumber { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
