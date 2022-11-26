using CrudTest.Bussiness.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.DataAccess.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _context;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
 
    }
}
