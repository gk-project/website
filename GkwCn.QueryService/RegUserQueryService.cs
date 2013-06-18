using GkwCn.Domains;
using GkwCn.Framework.Data;
using GkwCn.Framework.QueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Service
{
    public class RegUserQueryService:AbstractQueryService
    {
        public IEnumerable<RegUser> GetActionyRegUsers()
        {
            using (var query = UnitOfWork)
            {
                return query.Query<RegUser>().Where(u => u.Level == UserStatue.Actiony).ToList();
            }
        }

        public RegUser GetUserById(int id)
        {
            return UnitOfWork.Get<RegUser>(id);
        }
    }
}
