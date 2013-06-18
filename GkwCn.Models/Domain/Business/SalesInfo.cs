using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Business
{
    public class SalesInfo : BaseDomainObject
    {
        /// <summary>
        /// 库存量
        /// </summary>
        [MaxLength(20)]
        public string Amount { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [MaxLength(20)]
        public string Price { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(500)]
        public string Content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        [MaxLength(20)]
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [MaxLength(200)]
        public string Model { get; set; }

        [MaxLength(19)]
        public string BaseProductModelOId { get; set; }

        [MaxLength(19)]
        public string ProductSeriesOId { get; set; }

        public int? BrandId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? SalesId { get; set; }

        #region 关联属性
        public virtual Sales Sales { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductType ProductType { get; set; }
        #endregion
    }
}
