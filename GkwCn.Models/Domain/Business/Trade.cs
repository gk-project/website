using GkwCn.Domains.BaseData;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
=======
using GkwCn.Models.Commands.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
>>>>>>> gongqiu
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.Business
{
    public class Trade : BaseDomainObject
    {
<<<<<<< HEAD
=======
        [DisplayName("标题")]
>>>>>>> gongqiu
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [MaxLength(200)]
<<<<<<< HEAD
        public string Model { get; set; }

        [MaxLength(100)]
        public string LinkMan { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 有效天数
        /// </summary>
=======
        [DisplayName("型号")]
        public string Model { get; set; }

        /// <summary>
        /// 联系方式(QQ/MSN)
        /// </summary>
        [MaxLength(100)]
        [DisplayName("QQ/MSN")]
        public string OtherLink { get; set; }

        [MaxLength(100)]
        [DisplayName("联系人")]
        public string LinkMan { get; set; }

        [MaxLength(20)]
        [DisplayName("座机号")]
        public string Phone { get; set; }

        [MaxLength(20)]
        [DisplayName("手机号")]
        public string Handset { get; set; }

        [MaxLength(100)]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [MaxLength(20)]
        [DisplayName("传真号")]
        public string Fax { get; set; }

        [MaxLength(100)]
        [DisplayName("公司名称")]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        [DisplayName("通讯地址")]
        public string Address { get; set; }

        /// <summary>
        /// 有效天数
        /// </summary>
        [DisplayName("有效天数")]
>>>>>>> gongqiu
        public int TermDay { get; set; }

        /// <summary>
        /// 是否超期
        /// </summary>
<<<<<<< HEAD
=======
        [DisplayName("是否超期")]
>>>>>>> gongqiu
        public bool IsTimeout { get; set; }

        /// <summary>
        /// 生产商
        /// </summary>
        [MaxLength(100)]
<<<<<<< HEAD
=======
        [DisplayName("生产商")]
>>>>>>> gongqiu
        public string Manufacturer { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        [MaxLength(20)]
<<<<<<< HEAD
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

=======
        [DisplayName("库存量")]
        public string Amount { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [MaxLength(20)]
        [DisplayName("单价")]
        public string Price { get; set; }

        [MaxLength(50)]
        [DisplayName("其它品牌")]
        public string SecondBrand { get; set; }

        [MaxLength(200)]
        [DisplayName("缩略图地址")]
        public string PictureUrl { get; set; }

        [DisplayName("是否核实")]
        public bool Auditing { get; set; }

        [DisplayName("供求类型")]
        public TradeType TradeType { get; set; }

        [DisplayName("正方")]
        public string Content { get; set; }

        [DisplayName("品牌")]
        public int? BrandId { get; set; }

        [DisplayName("发布人")]
        public int? PublishUserId { get; set; }

        [DisplayName("产品类型")]
        public int? ProductTypeId { get; set; }

        [DisplayName("公司")]
>>>>>>> gongqiu
        public int? CompanyId { get; set; }

        #region 关联属性
        public virtual Company Company { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("PublishUserId")]
        public virtual RegUser PublishUser { get; set; }
        #endregion
<<<<<<< HEAD
=======

        public void InitDomain(CreateTradeCmd cmd)
        {
            Address = cmd.Address;
            Amount = cmd.Amount;
            BrandId = cmd.BrandId;
            CompanyId = cmd.CompanyId;
            CompanyName = cmd.CompanyName;
            Content = cmd.Content;
            Email = cmd.Email;
            Fax = cmd.Fax;
            Handset = cmd.Handset;
            Keyword = cmd.Keyword;
            LinkMan = cmd.LinkMan;
            Manufacturer = cmd.Manufacturer;
            Model = cmd.Model;
            OtherLink = cmd.OtherLink;
            Phone = cmd.Phone;
            PictureUrl = cmd.PictureUrl;
            Price = cmd.Price;
            ProductTypeId = cmd.ProductTypeId;
            PublishUserId = cmd.RegUserId;
            SecondBrand = cmd.SecondBrand;
            Summary = cmd.Summary;
            TermDay = cmd.TermDay;
            Title = cmd.Title;
            TradeType = cmd.TradeType;
            if (PublishUserId <= 0)
            {
                PublishUserId = 1;
            }
            if (Id <= 0)
            {
                CreateTime = DateTime.Now;
                Statue = DomainStatue.Effective;
                Hit = 0;
                Sequence = 0;
            }
            UpdateTime = DateTime.Now;
        }

        public EditTradeCmd DomainToEditCmd(EditTradeCmd cmd)
        {
            cmd.Address = Address;
            cmd.Amount = Amount;
            cmd.CompanyName = CompanyName;
            cmd.Content = Content;
            cmd.Email = Email;
            cmd.Fax = Fax;
            cmd.Handset = Handset;
            cmd.Id = Id;
            cmd.Keyword = Keyword;
            cmd.LinkMan = LinkMan;
            cmd.Manufacturer = Manufacturer;
            cmd.Model = Model;
            cmd.OtherLink = OtherLink;
            cmd.Phone = Phone;
            cmd.PictureUrl = PictureUrl;
            cmd.Price = Price;
            cmd.SecondBrand = SecondBrand;
            cmd.Summary = Summary;
            cmd.TermDay = TermDay;
            cmd.Title = Title;
            cmd.TradeType = TradeType;
            cmd.ProductTypeId = ProductTypeId;
            cmd.BrandId = BrandId;
            cmd.CompanyId = CompanyId;
            if (PublishUserId != null && PublishUserId.HasValue)
                cmd.RegUserId = PublishUserId.Value;
            return cmd;
        }
>>>>>>> gongqiu
    }
}
