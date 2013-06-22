using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Business
{
    public class Trade : BaseDomainObject
    {
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [MaxLength(200)]
        public string Model { get; set; }

        /// <summary>
        /// 联系方式(QQ/MSN)
        /// </summary>
        [MaxLength(100)]
        public string OtherLink { get; set; }

        [MaxLength(100)]
        public string LinkMan { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Handset { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 有效天数
        /// </summary>
        public int TermDay { get; set; }

        /// <summary>
        /// 是否超期
        /// </summary>
        public bool IsTimeout { get; set; }

        /// <summary>
        /// 生产商
        /// </summary>
        [MaxLength(100)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        [MaxLength(20)]
        public string Amount { get; set; }

        [MaxLength(50)]
        public string SecondBrand { get; set; }

        [MaxLength(200)]
        public string PictureUrl { get; set; }

        public bool Auditing { get; set; }

        public TradeType TradeType { get; set; }

        public string Content { get; set; }

        public int? BrandId { get; set; }

        public int? PublishUserId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? CompanyId { get; set; }

        #region 关联属性
        public virtual Company Company { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("PublishUserId")]
        public virtual RegUser PublishUser { get; set; }
        #endregion
    }
}
