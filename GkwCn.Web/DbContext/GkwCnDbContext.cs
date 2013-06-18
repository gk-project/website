using GkwCn.Domains;
using GkwCn.Domains.BaseData;
using GkwCn.Domains.Business;
using GkwCn.Domains.News;
using GkwCn.Domains.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Web.Data
{
    public class GkwCnDbContext:DbContext
    {
        private static string _defaultKey = "DefaultConnection";
        public static string DefaultConnnectionKey { get { return _defaultKey; } set { _defaultKey = value; } }

        public GkwCnDbContext()
            : this(DefaultConnnectionKey)
        { }

        public GkwCnDbContext(string connKey)
            : base(connKey)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<RegUser> RegUserList { get; set; }

        public DbSet<RegUserLog> RegUserLogList { get; set; }

        public DbSet<Brand> BrandList { get; set; }

        public DbSet<Industry> IndustryList { get; set; }

        public DbSet<Logo> LogoList { get; set; }

        public DbSet<ProductType> ProductTypeList { get; set; }

        public DbSet<ProvinceCity> ProvinceCityList { get; set; }

        public DbSet<Region> RegionList { get; set; }

        public DbSet<News> NewsList { get; set; }

        public DbSet<Company> CompanyList { get; set; }

        public DbSet<Product> ProductList { get; set; }

        public DbSet<Trade> TradeList { get; set; }

        public DbSet<Cooperate> CooperateList { get; set; }

        public DbSet<Sales> SalesList { get; set; }

        public DbSet<SalesInfo> SalesInfoList { get; set; }

        public DbSet<SalesProductType> SalesProductTypeList { get; set; }
    }
}
