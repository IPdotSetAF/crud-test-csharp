using CrudTest.Bussiness.Domain.RepositoryInterfaces;
using CrudTest.Bussiness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CrudTest.Bussiness.Domain.Entities.ValueObjects;

namespace CrudTest.DataAccess.Presistance.Repositories
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

        public async Task<bool> EmailExists(Email email) =>
            (await FindByCondition(c => c.Email.Value.Equals(email.Value), false)
                .FirstOrDefaultAsync()) != null;

        public async Task<bool> CustomerExists(Person person) =>
            (await FindByCondition(c => c.Person.FirstName.Equals(person.FirstName) &&
                                        c.Person.LastName.Equals(person.LastName) &&
                                        c.Person.DateOfBirth == person.DateOfBirth, false)
                .FirstOrDefaultAsync()) != null;
    }
}
