using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains
{
    public class BaseDomainObject
    {
        #region 领域模型属性
        public int Id { get; set; }

        [StringLength(19,MinimumLength=19)]
        [Column(TypeName="char")]
        public string OldId { get; set; }

        [Required]
        public DomainStatue Statue { get; set; }

        public int Sequence { get; set; }

        [DisplayName("关键词")]
        [MaxLength(200)]
        public string Keyword { get; set; }

        [DisplayName("描述")]
        [MaxLength(500)]
        public string Summary { get; set; }

        [DisplayName("浏览量")]
        public int Hit { get; set; }

        [DisplayName("创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        #endregion

        //#region 外键属性
        ////[ForeignKey("RegUserId")]
        //public virtual RegUser Writer { get; set; }

        ////[ForeignKey("BrandId")]
        //public virtual Brand Brand { get; set; }

        ////[ForeignKey("ProductTypeId")]
        //public ProductType ProductType { get; set; }

        ////[ForeignKey("IndustryId")]
        //public virtual Industry Industry { get; set; }
        //#endregion

        public void UpdateHit()
        {
            if (Statue == DomainStatue.Effective)
                Hit++;
        }

        public void Delete()
        {
            Statue = DomainStatue.Delete;
        }

        public void RollbackStatue()
        {
            Statue = DomainStatue.Effective;
        }
    }
}
