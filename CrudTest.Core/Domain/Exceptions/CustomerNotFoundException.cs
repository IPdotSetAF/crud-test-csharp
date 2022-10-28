namespace CrudTest.Core.Domain.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid customerId) 
            : base($"The customer with the identifier {customerId} was not found.")
        {
        }
    }
}
