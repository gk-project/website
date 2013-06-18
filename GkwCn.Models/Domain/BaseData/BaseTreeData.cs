using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.BaseData
{
    public class BaseTreeData:BaseSingleData
    {
        public int? ParentId { get; set; }

        public byte Level { get; set; }

        public byte ChildCount { get; set; }
    }
}
