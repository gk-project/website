using GkwCn.Framework.Data;
using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands
{
    public abstract class AbstractCommandExecuter<T> : ICommandExecuter<T>,IDisposable where T : ICommand
    {
        protected IDbContext UnitOfWork { get; private set; }

        protected AbstractCommandExecuter()
            : this(UnitOfWorkContext.Current ?? GkwCnEnvironment.Instance.UnitOfWorkFactory())
        {
        }

        protected AbstractCommandExecuter(IUnitOfWork unitOfWork)
        {
            Require.NotNull(unitOfWork, "unitOfWork");
            UnitOfWork = (IDbContext)unitOfWork;
        }

        public abstract object Execute(T cmd);

        public void Dispose()
        {
            if (UnitOfWork != null)
                UnitOfWork.Dispose();
        }
    }
}
