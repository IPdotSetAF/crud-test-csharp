using CrudTest.Core.Domain.Entities;

namespace CrudTest.Core.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool trackChanges, CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid customerId, bool trackChanges, CancellationToken cancellationToken = default);
        void Insert(Customer customer);
        void Remove(Customer customer);
    }
}
