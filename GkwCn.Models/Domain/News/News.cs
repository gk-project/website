using GkwCn.Domains.BaseData;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.News
{
    public class News : BaseDomainObject
    {
        public NewsType NewsType { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        [MaxLength(200)]
        public string SubHead { get; set; }

        [Required]
        public DateTime PublishTime { get; set; }

        [MaxLength(200)]
        public string PictureUrl { get; set; }

        public int? BrandId { get; set; }

        public int? WriterId { get; set; }

        public int? CompanyId { get; set; }

        #region 外键属性
        public virtual RegUser Writer { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Company Company { get; set; }
        #endregion

        #region 业务逻辑
        public void InitDomain(CreateNewsCmd cmd)
        {
            Title = cmd.Title;
            Content = cmd.Content;
            SubHead = cmd.SubHead;
            Keyword = cmd.Keyword;
            Summary = cmd.Summary;
            PictureUrl = cmd.PictureUrl;
            NewsType = cmd.Type;
            CompanyId = cmd.CompanyId;
            BrandId = cmd.BrandId;
            WriterId = cmd.RegUserId;
            if (WriterId <= 0)
                WriterId = 1;
            Statue = DomainStatue.Effective;
            if (Id <= 0)
                CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            PublishTime = DateTime.Now;
        }

        public void DomainToEditCmd(EditNewsCmd cmd)
        {
            cmd.Title = Title;
            cmd.Content = Content;
            cmd.SubHead = SubHead;
            cmd.Keyword = Keyword;
            cmd.Summary = Summary;
            cmd.PictureUrl = PictureUrl;
            cmd.Type = NewsType;
            cmd.CompanyId = CompanyId;
            cmd.BrandId = BrandId;
            if (WriterId.HasValue)
                cmd.RegUserId = WriterId.Value;
            if (cmd.RegUserId <= 0)
                cmd.RegUserId = 1;
        }
        #endregion
    }
}
