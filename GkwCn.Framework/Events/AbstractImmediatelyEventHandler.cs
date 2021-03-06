﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GkwCn.Framework.Data;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Events
{
    public abstract class AbstractImmediatelyEventHandler<TEvent> : IImmediatelyEventHandler<TEvent>,IDisposable
        where TEvent : IEvent
    {
        protected IDbContext UnitOfWork { get; private set; }

        protected AbstractImmediatelyEventHandler()
            : this(UnitOfWorkContext.Current ?? GkwCnEnvironment.Instance.UnitOfWorkFactory())
        {
        }

        protected AbstractImmediatelyEventHandler(IUnitOfWork unitOfWork)
        {
            Require.NotNull(unitOfWork, "unitOfWork");
            UnitOfWork = (IDbContext)unitOfWork;
        }

        public abstract void Handle(TEvent evnt);

        public void Dispose()
        {
            if (UnitOfWork != null)
                UnitOfWork.Dispose();
        }
    }
}
