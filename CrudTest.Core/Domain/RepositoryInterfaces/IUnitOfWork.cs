using System.Threading.Tasks;

namespace CrudTest.Core.Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
