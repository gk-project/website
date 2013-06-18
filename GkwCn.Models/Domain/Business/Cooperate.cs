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
    /// <summary>
    /// 商务合作
    /// </summary>
    public class Cooperate : BaseDomainObject
    {
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string SubHead { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

        public int TermDay { get; set; }

        public CooperateType Type { get; set; }

        /// <summary>
        /// 合作区域
        /// </summary>
        [MaxLength(200)]
        public string AreaInsutry { get; set; }

        public string Content { get; set; }

        public int? CompanyId { get; set; }

        public int? PublishUserId { get; set; }

        public int? BrandId { get; set; }

        #region 关联属性
        public virtual Brand Brand { get; set; }
        [ForeignKey("PublishUserId")]
        public virtual RegUser PublishUser { get; set; }
        public virtual Company Company { get; set; }
        #endregion
    }
}
