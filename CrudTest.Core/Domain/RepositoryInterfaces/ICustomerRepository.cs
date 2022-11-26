using CrudTest.Bussiness.Domain.Entities;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;

namespace CrudTest.Bussiness.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool trackChanges, CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid customerId, bool trackChanges, CancellationToken cancellationToken = default);
        void Insert(Customer customer);
        void Remove(Customer customer);
        Task<bool> EmailExists(Email email);
        Task<bool> CustomerExists(Person person);
    }
}
