namespace CrudTest.Core.Contracts.DTOs.Customer
{
    public class CustomerCreateDTO : CustomerUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
