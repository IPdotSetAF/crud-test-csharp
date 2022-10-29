using CrudTest.Core.Domain.RepositoryInterfaces;
using CrudTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CrudTest.Core.Domain.Entities.ValueObjects;

namespace CrudTest.Infrastructure.Presistance.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(bool trackChanges, CancellationToken cancellationToken = default) =>
            await FindAll(trackChanges)
                .ToListAsync(cancellationToken);

        public async Task<Customer?> GetByIdAsync(Guid customerId, bool trackChanges, CancellationToken cancellationToken = default) =>
            await FindByCondition(c => c.Id == customerId, trackChanges)
                .SingleOrDefaultAsync(cancellationToken);

        public void Insert(Customer customer) => Create(customer);

        public void Remove(Customer customer) => Delete(customer);

        public async Task<bool> EmailExists(Email email) => false;

        public async Task<bool> CustomerExists(Customer customer) => false;
    }
}
