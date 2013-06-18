using GkwCn.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.QueryServices
{
    public interface IQueryService
    {
        IDbContext UnitOfWork { get; }
    }
}
