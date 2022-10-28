using CrudTest.Core.Domain.RepositoryInterfaces;
using Moq;

namespace CrudTest.Test.SharedMocks
{
    public class MockRepositoryManager
    {
        public static Mock<IRepositoryManager> GetMock()
        {
            var mock = new Mock<IRepositoryManager>();
            var customerRepoMock = MockCustomerRepository.GetMock();
            var unitOfWorkMock = MockUnitOfWork.GetMock();

            mock.Setup(m => m.CustomerRepository).Returns(() => customerRepoMock.Object);

            mock.Setup(m => m.UnitOfWork).Returns(() => unitOfWorkMock.Object);

            return mock;
        }
    }
}
