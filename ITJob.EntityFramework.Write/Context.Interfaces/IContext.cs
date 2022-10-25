using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.EntityFramework.Write.Context.Interfaces
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
