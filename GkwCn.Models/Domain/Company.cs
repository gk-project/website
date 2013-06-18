using GkwCn.Domains.BaseData;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains
{
    public enum CompanyType
    {
        供应商 = 0,
        系统集成商 = 1,
        代理经销商 = 2,
        维修企业 = 3,
        培训机构 = 4,
        科研院所 = 5,
        其它 = 6
    }

    public class Company : BaseDomainObject
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string ShortName { get; set; }

        [MaxLength(200)]
        public string EnName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public string Description { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(14)]
        public string Zip { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Linkman { get; set; }

        [MaxLength(20)]
        public string Province { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(1000)]
        public string WorkProduct { get; set; }

        [MaxLength(200)]
        public string Logo { get; set; }

        public CompanyType Type { get; set; }

        [MaxLength(20)]
        public string Handset { get; set; }

        public int? RegUserId { get; set; }

        public virtual RegUser RegUser { get; set; }

        public string LogoUrl
        {
            get
            {
                if (Logo.IsNull())
                    return "~/comtent/images/defaultcompany.jpg";

                if (Logo.IndexOf("http://", StringComparison.CurrentCultureIgnoreCase) == -1)
                    return string.Format("http://www.gongkong.com{0}", Logo);
                return Logo;
            }
        }

        public void InitDomain(CreateCompanyCmd cmd)
        {
            Name = cmd.Title;
            EnName = cmd.EnName;
            ShortName = cmd.ShortName;
            Description = cmd.Content;
            Summary = cmd.Summary;
            Keyword = cmd.Keyword;
            Logo = cmd.Logo;
            Address = cmd.Address;
            Email = cmd.Email;
            Handset = cmd.Handset;
            Mobile = cmd.Mobile;
            City = cmd.City;
            Province = cmd.Province;
            Fax = cmd.Fax;
            Linkman = cmd.LinkMan;
            Statue = DomainStatue.Effective;
            Type = cmd.Type;
            WorkProduct = cmd.WorkProduct;
            Zip = cmd.Zip;
            RegUserId = cmd.RegUserId;
            Sequence = 0;
            Hit = 0;
            if (Id <= 0)
                this.CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public void DomainToEditCmd(EditCompanyCmd cmd)
        {
            cmd.Title = Name;
            cmd.EnName = EnName;
            cmd.ShortName = ShortName;
            cmd.Content = Description;
            cmd.Summary = Summary;
            cmd.Keyword = Keyword;
            cmd.Logo = Logo;
            cmd.Address = Address;
            cmd.Email = Email;
            cmd.Handset = Handset;
            cmd.Mobile = Mobile;
            cmd.City = City;
            cmd.Province = Province;
            cmd.Fax = Fax;
            cmd.LinkMan = Linkman;
            cmd.Type = Type;
            cmd.WorkProduct = WorkProduct;
            cmd.Zip = Zip;
            cmd.RegUserId = RegUserId.Value;
        }
    }
}
