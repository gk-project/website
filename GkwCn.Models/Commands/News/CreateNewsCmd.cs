using GkwCn.Domains;
using GkwCn.Domains.BaseData;
using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands
{
    public class CreateNewsCmd : BaseDomainCmd
    {
        [MaxLength(100)]
        [DisplayName("子标题")]
        public string SubHead { get; set; }

        [MaxLength(200)]
        [DisplayName("图片Url")]
        public string PictureUrl { get; set; }

        [Required]
        [DisplayName("新闻类型")]
        public NewsType Type { get; set; }

        [DisplayName("品牌")]
        public int? BrandId { get; set; }

        [DisplayName("公司")]
        public int? CompanyId { get; set; }

        #region 关联属性
        public virtual Brand Brand { get; set; }

        public virtual Company Company { get; set; }
        #endregion
    }
}
