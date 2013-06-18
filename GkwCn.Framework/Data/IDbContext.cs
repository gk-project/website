using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Data
{
    public interface IDbContext : IUnitOfWork
    {
        T Get<T>(object id) where T : class;

        IQueryable<T> Query<T>() where T : class;

        T NewObject<T>() where T : class;

        void Save<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
    }
}
