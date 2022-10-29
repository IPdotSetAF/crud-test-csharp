namespace CrudTest.Core.Domain.Exceptions
{
    public class InvalidBankAccountNumberException : BadRequestException
    {
        public InvalidBankAccountNumberException(ulong value) 
            : base($"{value} is not a valid bank account number")
        {
        }
    }
}
