using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .ToListAsync();

        public async Task<Customer?> GetCustomerAsync(Guid customerId, bool trackChanges) =>
            await FindByCondition(c => c.Id == customerId, trackChanges)
                .SingleOrDefaultAsync();

        public void CreateCustomer(Customer customer) =>
            Create(customer);

        public void DeleteCustomer(Customer customer) =>
            Delete(customer);

        public void UpdateCustomer(Customer customer) =>
            Update(customer);

        public async Task<bool> EmailExists(string email) =>
            (await FindByCondition(c => c.Email.Equals(email), false)
                .FirstOrDefaultAsync()) != null;

        public async Task<bool> CustomerExists(Customer customer) =>
            (await FindByCondition(c => c.FirstName.Equals(customer.FirstName) &&
                                        c.LastName.Equals(customer.LastName) &&
                                        c.DateOfBirth == customer.DateOfBirth, false)
                .FirstOrDefaultAsync()) != null;
    }
}
