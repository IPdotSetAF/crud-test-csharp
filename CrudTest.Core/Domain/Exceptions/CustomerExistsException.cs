namespace CrudTest.Core.Domain.Exceptions
{
    public class CustomerExistsException : BadRequestException
    {
        public CustomerExistsException(string firstName, string lastName , DateOnly dateOfBirth)
            : base($"The customer with the FirstName {firstName}, LastName {lastName}, DateOfBirth {dateOfBirth.ToShortDateString} already exists.")
        {
        }

        public CustomerExistsException(string email)
            : base($"The customer with the Email {email} already exists.")
        {
        }
    }
}
