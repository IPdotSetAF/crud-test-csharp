using Contracts;
using Entities;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
        }

        private ICustomerRepository _customer;
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_context);
                return _customer;
            }
        }

        public void Save() => _context.SaveChanges();

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
