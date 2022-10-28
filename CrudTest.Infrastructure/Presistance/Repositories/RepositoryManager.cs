using CrudTest.Core.Domain.RepositoryInterfaces;

namespace CrudTest.Infrastructure.Presistance.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;

        private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));

            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(_context));
        }

        public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
