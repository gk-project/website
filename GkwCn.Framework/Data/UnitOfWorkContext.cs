using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GkwCn.Framework.Data;
using GkwCn.Framework.Events;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Data
{
    public static class UnitOfWorkContext
    {
        [ThreadStatic]
        private static IDbContext _current;

        public static IDbContext Current
        {
            get
            {
                return _current;
            }
        }

        public static void Bind(IDbContext unitOfWork)
        {
            Require.NotNull(unitOfWork, "unitOfWork");
            _current = unitOfWork;
        }

        public static void Unbind()
        {
            _current = null;
        }
    }
}
