using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Data
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Copy(T source, T target);
        void Submit();

        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> Table { get; }

        int Count(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,IQueryable<T>> order);
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order, int skip, int count);
    }
}
