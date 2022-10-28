using CrudTest.Core.Domain.Entities.ValueObjects;
using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace CrudTest.Core.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public ulong BankAccountNumber { get; set; }
    }
}
