using CrudTest.Core.Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace CrudTest.Core.Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        public ICustomerRepository CustomerRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}
