using GkwCn.Domains.BaseData;
using GkwCn.Framework.QueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.QueryService
{
    public class ProvinceCityQueryService : AbstractQueryService
    {
        public IEnumerable<ProvinceCity> GetProvinces()
        {
            return UnitOfWork.Query<ProvinceCity>().Where(o => o.Statue == Domains.DomainStatue.Effective && !o.ParentId.HasValue).OrderBy(o => o.Sequence).ToList();
        }

        public IEnumerable<ProvinceCity> GetCitys(int provinceid)
        {
            return UnitOfWork.Query<ProvinceCity>().Where(o => o.Statue == Domains.DomainStatue.Effective && o.ParentId == provinceid).OrderBy(o => o.Sequence).ToList();
        }

        public IEnumerable<ProvinceCity> GetCitys(string pname)
        {
            var db = UnitOfWork;
            var pid = db.Query<ProvinceCity>().FirstOrDefault(p => p.Name == pname).Id;
            return db.Query<ProvinceCity>().Where(o => o.Statue == Domains.DomainStatue.Effective && o.ParentId == pid).OrderBy(o => o.Sequence).ToList();
        }
    }
}
