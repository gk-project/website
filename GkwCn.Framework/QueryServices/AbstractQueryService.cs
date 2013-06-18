using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.QueryServices
{
    public abstract class AbstractQueryService : IQueryService, IDisposable
    {
        public Data.IDbContext UnitOfWork
        {
            get { return (Data.IDbContext)GkwCn.Framework.Utils.GkwCnEnvironment.Instance.UnitOfWorkFactory(); }
        }

        public void Dispose()
        {
            if (UnitOfWork != null)
                UnitOfWork.Dispose();
        }

        public T Get<T>(int id) where T : class
        {
            return UnitOfWork.Get<T>(id);
        }

        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return UnitOfWork.Query<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order) where T : class
        {
            return order(UnitOfWork.Query<T>().Where(predicate)).ToList();
        }

        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order, int index, int size, out int totalCount) where T : class
        {
            totalCount = UnitOfWork.Query<T>().Where(predicate).Count();
            return order(UnitOfWork.Query<T>().Where(predicate)).Skip(Math.Max(0, index - 1) * size).Take(size).ToList();
        }

        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order, BasePager page) where T : class
        {
            page.TotalCount = UnitOfWork.Query<T>().Where(predicate).Count();
            return order(UnitOfWork.Query<T>().Where(predicate)).Skip(Math.Max(0, page.Index - 1) * page.Size).Take(page.Size).ToList();
        }
    }
}
