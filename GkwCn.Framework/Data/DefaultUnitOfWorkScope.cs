using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkwCn.Framework.Data
{
    public class DefaultUnitOfWorkScope : GkwCn.Framework.Data.UnitOfWorkScope
    {
        public new EFUnitOfWork UnitOfWork
        {
            get
            {
                return (EFUnitOfWork)base.UnitOfWork;
            }
        }

        public DefaultUnitOfWorkScope()
        {
        }

        public DefaultUnitOfWorkScope(EFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
