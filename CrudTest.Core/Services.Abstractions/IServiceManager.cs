namespace CrudTest.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
    }
}
