using GkwCn.Domains;
using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GkwCn.Models.Commands
{
    public class BaseDomainCmd:ICommand
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("标题")]
        public virtual string Title { get; set; }

        [Required]
        [DisplayName("正文")]
        [AllowHtml]
        public virtual string Content { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("关键词")]
        public virtual string Keyword { get; set; }

        [Required]
        [MaxLength(500)]
        [DisplayName("描述")]
        public virtual string Summary { get; set; }

        [Required]
        public virtual int RegUserId { get; set; }

        public virtual RegUser RegUser { get; set; }
    }
}
