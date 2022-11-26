using System.Threading.Tasks;

namespace CrudTest.Bussiness.Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
