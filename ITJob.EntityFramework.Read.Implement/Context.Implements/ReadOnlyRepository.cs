using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.EntityFramework.Read.Context.Interfaces;

namespace ITJob.EntityFramework.Read.Implement.Context.Implements
{
    internal class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {

        private readonly ReadOnlyDataContext _context;

        private readonly DbSet<TEntity> _dbSet;
        private IQueryable<TEntity> _query;


        public ReadOnlyRepository()
        {
            _context = new ReadOnlyDataContext();
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _dbSet.FindAsync(keyValues);
        }

        public IQueryable<TEntity> AsQuery()
        {
            return _dbSet.AsQueryable();
        }


        public IQueryable<TEntity> SqlQuery(string storedProcedure, Dictionary<string, object> parameteres)
        {
            if (parameteres != null && parameteres.Count > 0)
            {
                object[] sqlParameters = new SqlParameter[parameteres.Count];
                int index = 0;
                foreach (var parametere in parameteres)
                {
                    SqlParameter sqlParameter = new SqlParameter(parametere.Key, parametere.Value);
                    sqlParameters[index] = sqlParameter;
                    index++;
                }
                return _context.Database.SqlQuery<TEntity>(storedProcedure, sqlParameters).AsQueryable();
            }

            return _context.Database.SqlQuery<TEntity>(storedProcedure).AsQueryable();
        }
    }
}
