using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GkwCn.Framework.Events;
using GkwCn.Framework.Events.Buses;
using GkwCn.Framework.Data;
using System.Data.Entity;
using GkwCn.Framework.Utils;

namespace GkwCn.Web.Data
{
    public class EFUnitOfWork : AbstractUnitOfWork,IDbContext
    {
        #region 静态属性与方法
        /// <summary>
        /// 数据库操作上下文
        /// </summary>
        protected DbContext Db { get; private set; }

        /// <summary>
        /// 默认的数据库连接字符串名称
        /// </summary>
        public static string DefaultDbConnectionName { get; set; }

        /// <summary>
        /// 使用默认的数据库连接字符串获取一个新的工作单元
        /// </summary>
        //public static EFUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return new EFUnitOfWork();
        //    }
        //}

        /// <summary>
        /// 根据指定的数据库连接字符串名称获取工作单元对象
        /// </summary>
        /// <param name="connKey"></param>
        /// <returns></returns>
        //public static EFUnitOfWork GetUnitOfWork(string connKey)
        //{
        //    return new EFUnitOfWork(connKey);
        //}
        #endregion

        #region 工作单元的构造函数
        //private EFUnitOfWork()
        //{
        //    Db = new DbContext(DefaultDbConnectionName);
        //}

        //private EFUnitOfWork(string key)
        //{
        //    Db = new DbContext(key);
        //}

        public EFUnitOfWork(DbContext db)
            : this(db, GkwCnEnvironment.Instance.PostCommitEventBus)
        {
        }

        public EFUnitOfWork(DbContext db, IEventBus eventBus)
            : base(eventBus)
        {
            Db = db;
            DisableDTC = true;
        }
        #endregion

        #region 数据操作方法
        public T Get<T>(object id) where T : class
        {
            return Db.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Db.Set<T>();
        }

        public T NewObject<T>()
            where T : class
        {
            return Db.Set<T>().Create();
        }

        public void Save<T>(T entity) where T : class
        {
            Db.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity)where T : class
        {
            Db.Set<T>().Remove(entity);
        }

        protected override void DoCommit()
        {
            Db.SaveChanges();
        }

        public override void Execute()
        {
            Db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}
