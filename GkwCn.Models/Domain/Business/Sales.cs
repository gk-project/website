using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Business
{
    public class Sales:BaseDomainObject
    {
        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string Factory { get; set; }

        public DateTime EndTime { get; set; }

        public string ProductSeriesOId { get; set; }

        public int? BrandId { get; set; }

        public int? PublishUserId { get; set; }

        public int? ProductId { get; set; }

        public int? CompanyId { get; set; }

        #region 关联属性
        public virtual Brand Brand { get; set; }
        public virtual Product.Product Product { get; set; }
        [ForeignKey("PublishUserId")]
        public virtual RegUser PublishUser { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<SalesInfo> SalesInfos { get; set; }
        #endregion
    }
}
