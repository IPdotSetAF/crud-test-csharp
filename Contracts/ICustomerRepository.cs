using Entities.Models;

namespace Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges);
        Task<Customer?> GetCustomerAsync(Guid customerId, bool trackChanges);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<bool> EmailExists(string email);
        Task<bool> CustomerExists(Customer customer);
    }
}
