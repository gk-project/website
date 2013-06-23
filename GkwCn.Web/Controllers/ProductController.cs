using GkwCn.Domains;
using GkwCn.Domains.Product;
using GkwCn.Framework.Commands.Buses;
using GkwCn.Framework.Mvc;
using GkwCn.Models.Commands;
using GkwCn.Models.ViewModels;
using GkwCn.QueryService;
using GkwCn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Controllers
{
    public class ProductController : BaseController
    {
        private static Random random = new Random(99999);
        ProductQueryService query = new ProductQueryService();

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }

        [OutputCache(Duration = 300, VaryByParam = "type;size;index;")]
        public ActionResult Index(int? type, Pager page)
        {
            IEnumerable<Product> produsts = null;
            if (type.IsNull() || !type.HasValue || type.Value < 0)
                produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(p.PictureUrl), ps => ps.OrderByDescending(p => p.PublishTime), page);
            else
                produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(p.PictureUrl) && p.ProductTypeId == type, ps => ps.OrderByDescending(p => p.PublishTime), page);
            var param = new Dictionary<string, object>();
            param["type"] = type;
            page.ParamObj = param;
            return View(new ProductListViewModel() { ProductTypeId = type ?? -1, ListValue = produsts, Page = page });
        }

        [OutputCache(Duration = 300, VaryByParam = "companyid;size;index;")]
        public ActionResult GetProductByCId(int companyid, Pager page)
        {
            var company = query.Get<Company>(companyid);
            var produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && p.CompanyId == companyid && !string.IsNullOrEmpty(p.PictureUrl), ps => ps.OrderByDescending(p => p.PublishTime), page);
            return PartialView(new ProductListViewModel() { CompanyId = companyid, CompanyName = company.Name, ListValue = produsts, Page = page });
        }

        //[OutputCache(Duration = 300, VaryByParam = "type;index;view;size;israndom;")]
        public ActionResult GetPartialList(string view, int? type, Pager page, bool? isRandom = true)
        {
            if (isRandom.Value)
                page.Index = random.Next(0, 100);
            IEnumerable<Product> produsts = null;
            if (type.IsNull() || !type.HasValue || type.Value < 0)
                produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(p.PictureUrl), ps => ps.OrderByDescending(p => p.PublishTime), page);
            else
                produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(p.PictureUrl) && p.ProductTypeId == type, ps => ps.OrderByDescending(p => p.PublishTime), page);
            return PartialView(view ?? "GetPartialList", new ProductListViewModel() { ProductTypeId = type ?? -1, ListValue = produsts, Page = page });
        }

        [OutputCache(Duration = 300, VaryByParam = "index;")]
        public ActionResult ProductsByHit(Pager page)
        {
            IEnumerable<Product> produsts = query.GetList<Product>(p => p.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(p.PictureUrl), ps => ps.OrderByDescending(p => p.Hit), page);
            return PartialView(new ProductListViewModel() { ProductTypeId = -1, ListValue = produsts, Page = page });
        }

        public ActionResult Details(int id)
        {
            var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, Product>(new UpdateHitCmd() { Id = id, Type = SiteType.PRODUCT });
            if (domain == null || domain.Statue != DomainStatue.Effective)
                return HttpNotFound();
            return View(domain);
        }

        //public ActionResult Delete(DeleteDomainCmd cmd)
        //{
        //    cmd.Type = SiteType.PRODUCT;
        //    DefaultCommandBus.Instance.SendCommand(cmd);
        //    return RedirectToAction("index");
        //}

        public ActionResult Rollback(RollbackDomainCmd cmd)
        {
            cmd.Type = SiteType.PRODUCT;
            DefaultCommandBus.Instance.SendCommand(cmd);
            return RedirectToAction("details", new { id = cmd.Id });
        }
    }
}
