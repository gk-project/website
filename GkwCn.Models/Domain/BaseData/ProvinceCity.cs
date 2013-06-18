using GkwCn.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.BaseData
{
    /// <summary>
    /// 省市基础数据
    /// </summary>
    public class ProvinceCity:BaseTreeData
    {
        public int RegionId { get; set; }
    }
}
