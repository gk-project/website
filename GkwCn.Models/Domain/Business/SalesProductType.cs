using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Business
{
    public class SalesProductType
    {
        public int Id { get; set; }

        public DomainStatue Statue { get; set; }

        public int? ProductTypeId { get; set; }

        public int? SalesId { get; set; }

        #region 关联属性
        public virtual ProductType ProductType { get; set; }
        public virtual Sales Sales { get; set; }
        #endregion
    }
}
