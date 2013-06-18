using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Product
{
    public class Product : BaseDomainObject
    {
        [MaxLength(200)]
        public string Name { get; set; }

        public string Content { get; set; }

        [MaxLength(200)]
        public string FactoryCn { get; set; }

        [MaxLength(200)]
        public string FactoryEn { get; set; }

        public DateTime PublishTime { get; set; }

        [MaxLength(200)]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string PictureUrl { get; set; }

        public int? BrandId { get; set; }

        public int? CompanyId { get; set; }

        public int PublishUserId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? ProductSeriesId { get; set; }

        #region 关联属性
        public virtual Company Company { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("PublishUserId")]
        public virtual RegUser RegUser { get; set; }
        #endregion
    }
}
