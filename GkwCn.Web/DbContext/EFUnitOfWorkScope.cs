using GkwCn.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkwCn.Web.Data
{
    public class EFUnitOfWorkScope : GkwCn.Framework.Data.UnitOfWorkScope
    {
        public new IDbContext UnitOfWork
        {
            get
            {
                return (IDbContext)base.UnitOfWork;
            }
        }

        public EFUnitOfWorkScope()
        {
        }

        public EFUnitOfWorkScope(IDbContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
