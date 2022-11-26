using CrudTest.Bussiness.Domain.Entities.ValueObjects;

namespace CrudTest.Bussiness.Domain.Exceptions
{
    public class CustomerExistsException : BadRequestException
    {
        public CustomerExistsException(Person person)
            : base($"The customer with the FirstName {person.FirstName}, LastName {person.LastName}, DateOfBirth {person.DateOfBirth.ToShortDateString()} already exists.")
        {
        }

        public CustomerExistsException(Email email)
            : base($"The customer with the Email {email.Value} already exists.")
        {
        }
    }
}
