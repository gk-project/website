using GkwCn.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands.Business
{
    public class CreateTradeCmd:BaseDomainCmd
    {
        public int Amount { get; set; }

        public bool Auditing { get; set; }

        public int? BrandId { get; set; }

        public int? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        [DisplayName("传真")]
        public string Fax { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [MaxLength(20)]
        [DisplayName("联系人")]
        public string LinkMan { get; set; }

        [DisplayName("联系电话")]
        public string Phone { get; set; }

        [DisplayName("生产厂家")]
        public string Manufacturer { get; set; }

        [DisplayName("有效天数")]
        public int TermDay { get; set; }

        [Required]
        [DisplayName("供求类型")]
        public TradeType TradeType { get; set; }

        [MaxLength(200)]
        [DisplayName("型号")]
        public string Model { get; set; }
    }
}
