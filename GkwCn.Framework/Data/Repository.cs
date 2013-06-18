using GkwCn.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Data
{
    public class Repository<T> : IRepository<T> where T : BaseDomain
    {
        private readonly DbContext _db;

        protected virtual DbContext Session
        {
            get { return _db; }
        }

        public virtual DbSet<T> Table
        {
            get { return Session.Set<T>(); }
        }

        #region IRepository<T> Members

        void IRepository<T>.Save(T entity)
        {
            Save(entity);
        }

        void IRepository<T>.Update(T entity)
        {
            Update(entity);
        }

        void IRepository<T>.Delete(T entity)
        {
            Delete(entity);
        }

        void IRepository<T>.Copy(T source, T target)
        {
            Copy(source, target);
        }

        void IRepository<T>.Submit()
        {
            Submit();
        }

        T IRepository<T>.Get(int id)
        {
            return Get(id);
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate);
        }

        IQueryable<T> IRepository<T>.Table
        {
            get { return Table; }
        }

        int IRepository<T>.Count(Expression<Func<T, bool>> predicate)
        {
            return Count(predicate);
        }

        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).ToList();
        }

        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,IQueryable<T>> order)
        {
            return Fetch(predicate, order).ToList();
        }

        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order, int skip,
                                            int count)
        {
            return Fetch(predicate, order, skip, count).ToList();
        }

        #endregion

        public virtual T Get(int id)
        {
            return Table.First(o => o.Id == id);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).SingleOrDefault();
        }

        public virtual void Save(T entity)
        {
            Table.Add(entity);
        }

        public virtual void Update(T entity)
        {
            Table.Attach(entity);
        }

        public virtual void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public virtual void Copy(T source, T target)
        {
        }

        public virtual void Submit()
        {
            Session.SaveChanges();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).Count();
        }

        public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> order)
        {
            return order(Fetch(predicate));
        }

        public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,IQueryable<T>> order, int skip,
                                           int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }
    }
}
