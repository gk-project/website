﻿using GkwCn.Domains;
using GkwCn.Domains.BaseData;
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
        [MaxLength(20)]
        [DisplayName("库存数量")]
        public string Amount { get; set; }

        [MaxLength(50)]
        [DisplayName("其它品牌")]
        public string SecondBrand { get; set; }

        [Required]
        [DisplayName("是否审核")]
        public bool Auditing { get; set; }

        [MaxLength(100)]
        [DisplayName("公司名称")]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [MaxLength(20)]
        [DisplayName("传真")]
        public string Fax { get; set; }

        [MaxLength(20)]
        [DisplayName("联系人")]
        public string LinkMan { get; set; }

        [MaxLength(20)]
        [DisplayName("联系电话")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [DisplayName("生产厂家")]
        public string Manufacturer { get; set; }

        [DisplayName("有效天数")]
        public int TermDay { get; set; }

        [Required]
        [DisplayName("供求类型")]
        public TradeType TradeType { get; set; }

        [DisplayName("图片地址")]
        [MaxLength(200)]
        public string PictureUrl { get; set; }

        [MaxLength(200)]
        [DisplayName("型号")]
        public string Model { get; set; }

        public int? BrandId { get; set; }

        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
