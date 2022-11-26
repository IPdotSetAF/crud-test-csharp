using CrudTest.Bussiness.Domain.RepositoryInterfaces;
using CrudTest.Bussiness.Services.Abstractions;

namespace CrudTest.Bussiness.Services
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
