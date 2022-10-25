using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.EntityFramework.Write.Context.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        TEntity Find(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        IQueryable<TEntity> AsQuery();
        ISet<TEntity> WithInclude<TProperty>(Expression<Func<TEntity, TProperty>> include);
        ISet<TEntity> WithInclude(string include);


        void Update(TEntity entity);
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Remove(TEntity entity);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
    }
}
