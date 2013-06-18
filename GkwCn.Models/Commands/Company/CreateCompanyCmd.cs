using GkwCn.Domains;
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
    public class CreateCompanyCmd:BaseDomainCmd
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("公司址地")]
        public string Address { get; set; }

        [Required]
        [DisplayName("市")]
        public string City { get; set; }

        [Required]
        [DisplayName("省")]
        public string Province { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("公司座机")]
        public string Mobile { get; set; }

        [MaxLength(20)]
        [DisplayName("传真")]
        public string Fax { get; set; }

        [MaxLength(20)]
        [DisplayName("手机")]
        public string Handset { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayName("联系人")]
        public string LinkMan { get; set; }

        [MaxLength(20)]
        [DisplayName("公司简称")]
        public string ShortName { get; set; }

        [MaxLength(20)]
        [DisplayName("英文名称")]
        public string EnName { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("公司Logo")]
        public string Logo { get; set; }

        [Required]
        [DisplayName("公司类型")]
        public CompanyType Type { get; set; }

        [MaxLength(100)]
        [DisplayName("公司产品")]
        public string WorkProduct { get; set; }

        [MaxLength(10)]
        [DisplayName("邮政编码")]
        public string Zip { get; set; }

        [DisplayName("公司介绍")]
        public override string Content
        {
            get
            {
                return base.Content;
            }
            set
            {
                base.Content = value;
            }
        }

        [DisplayName("公司名称")]
        public override string Title
        {
            get
            {
                return base.Title;
            }
            set
            {
                base.Title = value;
            }
        }
    }
}
