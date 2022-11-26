using CrudTest.Bussiness.Domain.Entities.ValueObjects;

namespace CrudTest.Bussiness.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public BankAccountNumber BankAccountNumber { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        //this parameterless ctor is needed for EFCore to function and will not threaten null-safety.
        private Customer() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Customer(Guid id, Person person, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Id = id;
            Person = person;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public Customer(Person person, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber) 
            : this(Guid.NewGuid(), person, phoneNumber, email, bankAccountNumber) { }
    }
}
