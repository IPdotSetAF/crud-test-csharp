using CrudTest.Core.Domain.RepositoryInterfaces;
using Moq;


namespace CrudTest.Test.XUnitTests.Mocks
{
    internal class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();

            mock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Callback((CancellationToken cancellationToken) => { return; });

            return mock;
        }
    }
}
