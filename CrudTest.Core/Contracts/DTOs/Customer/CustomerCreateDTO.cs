using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CrudTest.Bussiness.Contracts.DTOs.Customer
{
    public class CustomerCreateDTO : CustomerUpdateDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
