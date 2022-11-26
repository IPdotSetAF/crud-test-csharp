namespace CrudTest.Bussiness.Domain.Exceptions
{
    public class InvalidPhoneNumberException : BadRequestException
    {
        public InvalidPhoneNumberException(string value) 
            : base($"{value} is not a valid phoneNumber")
        {
        }
    }
}
