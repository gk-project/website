using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Data
{
    public class UnitOfWorkScope : IDisposable
    {
        public IDbContext UnitOfWork { get; private set; }

        public UnitOfWorkScope()
            : this(GkwCnEnvironment.Instance.UnitOfWorkFactory())
        {
        }

        public UnitOfWorkScope(IUnitOfWork unitOfWork)
        {
            Require.NotNull(unitOfWork, "unitOfWork");

            UnitOfWork = (IDbContext)unitOfWork;
            UnitOfWork.IsAutoDispose = false;
            UnitOfWorkContext.Bind(UnitOfWork);
        }

        public void Dispose()
        {
            UnitOfWork.IsAutoDispose = true;
            UnitOfWork.Dispose();
            UnitOfWorkContext.Unbind();
        }
    }
}
