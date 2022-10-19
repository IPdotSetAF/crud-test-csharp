using Contracts;
using Moq;

namespace Mc2.CrudTest.AcceptanceTests.Mocks
{
    internal class MockRepositoryManager
    {
        public static Mock<IRepositoryManager> GetMock()
        {
            var mock = new Mock<IRepositoryManager>();
            var customerRepoMock=MockCustomerRepository.GetMock();

            mock.Setup(m => m.Customer).Returns(() => customerRepoMock.Object);

            mock.Setup(m => m.Save()).Callback(() => { return; });
            mock.Setup(m => m.SaveAsync()).Callback(() => { return; });

            return mock;
        }
    }
}
