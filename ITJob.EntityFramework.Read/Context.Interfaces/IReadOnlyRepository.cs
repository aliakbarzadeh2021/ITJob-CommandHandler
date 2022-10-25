using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.EntityFramework.Read.Context.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        IQueryable<TEntity> AsQuery();
        IQueryable<TEntity> SqlQuery(string storedProcedure, Dictionary<string, object> parameteres);
    }
}
