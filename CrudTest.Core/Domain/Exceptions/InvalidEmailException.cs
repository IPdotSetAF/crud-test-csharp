namespace CrudTest.Core.Domain.Exceptions
{
    internal class InvalidEmailException : BadRequestException
    {
        public InvalidEmailException(string value) 
            : base($"{value} is not a valid Email address")
        {
        }
    }
}
