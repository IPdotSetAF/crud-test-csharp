using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public virtual IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ? RepositoryContext.Set<T>() : RepositoryContext.Set<T>().AsNoTracking();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ? RepositoryContext.Set<T>().Where(expression) : RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public virtual void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public virtual void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public virtual void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
