using CrudTest.Core.Domain.RepositoryInterfaces;
using CrudTest.Core.Services.Abstractions;

namespace CrudTest.Core.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _lazyCustomerService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCustomerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
        }

        public ICustomerService CustomerService => _lazyCustomerService.Value;
    }
}
