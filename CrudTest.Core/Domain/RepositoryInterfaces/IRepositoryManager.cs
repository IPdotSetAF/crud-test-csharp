using CrudTest.Bussiness.Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace CrudTest.Bussiness.Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        public ICustomerRepository CustomerRepository { get; }

        public IUnitOfWork UnitOfWork { get; }
    }
}
