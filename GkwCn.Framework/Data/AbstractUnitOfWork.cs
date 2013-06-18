using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using GkwCn.Framework.Events;
using GkwCn.Framework.Events.Buses;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Data
{
    public abstract class AbstractUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private TransactionScopeOption _transactionScopeOption = TransactionScopeOption.Required;

        protected IEventBus EventBus { get; private set; }

        public bool IsAutoDispose { get; set; }

        public TransactionScopeOption TransactionScopeOption
        {
            get
            {
                return _transactionScopeOption;
            }
            set
            {
                _transactionScopeOption = value;
            }
        }

        protected bool DisableDTC { get; set; }

        protected AbstractUnitOfWork()
            : this(GkwCnEnvironment.Instance.PostCommitEventBus)
        {
        }

        protected AbstractUnitOfWork(IEventBus postCommitEventBus)
        {
            Require.NotNull(postCommitEventBus, "postCommitEventBus");
            EventBus = postCommitEventBus;
            IsAutoDispose = true;
        }

        ~AbstractUnitOfWork()
        {
            Dispose(false);
        }

        public virtual void Commit()
        {
            if (_disposed)
                throw new ObjectDisposedException(null, "Cannot commit a disposed unit of work.");

            if (DisableDTC)
            {
                DoCommit();
                OnCommitted();
            }
            else
            {
                using (var scope = new TransactionScope(_transactionScopeOption))
                {
                    DoCommit();
                    OnCommitted();
                    scope.Complete();
                }
            }

            PostCommitActions.Clear();
            DomainEvent.ClearAllThreadStaticPendingEvents();
        }

        protected virtual void OnCommitted()
        {
            ExecutePostCommitActions();
            PublishPostCommitEvents();
        }

        protected virtual void ExecutePostCommitActions()
        {
            foreach (var action in PostCommitActions.GetQueuedActions())
            {
                action();
            }
        }

        protected virtual void PublishPostCommitEvents()
        {
            foreach (var evnt in DomainEvent.GetThreadStaticPendingEvents())
            {
                EventBus.Publish(evnt);
            }
        }

        protected abstract void DoCommit();

        public void Dispose()
        {
            if (IsAutoDispose)
            {
                Dispose(IsAutoDispose);
                GC.SuppressFinalize(this);
                IsAutoDispose = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    PostCommitActions.Clear();
                    DomainEvent.ClearAllThreadStaticPendingEvents();
                }

                _disposed = true;
            }
        }

        public UnitOfWorkScope OpenUnitOfWorkScope()
        {
            DisableDTC = false;
            return new UnitOfWorkScope(this);
        }

        public abstract void Execute();
    }
}
