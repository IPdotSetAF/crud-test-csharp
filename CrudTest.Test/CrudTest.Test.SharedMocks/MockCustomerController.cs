using CrudTest.Bussiness.Services;
using CrudTest.Presentation.Server.Controllers;

namespace CrudTest.Test.SharedMocks
{
    public static class MockCustomerController
    {
        public static CustomerController CustomerController
        {
            get
            {
                var repositoryManagerMock = MockRepositoryManager.GetMock();
                var serviceManager = new ServiceManager(repositoryManagerMock.Object);
                return new CustomerController(serviceManager);
            }
        }
    }
}
