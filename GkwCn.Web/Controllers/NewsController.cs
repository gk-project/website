using GkwCn.Domains;
using GkwCn.Domains.News;
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
    public class NewsController : BaseController
    {
        private static Random random = new Random(99999);
        NewsQueryService query = new NewsQueryService();

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }

        [OutputCache(Duration = 300, VaryByParam = "type;index;size;view;")]
        public ActionResult Index(int? type, string view, Pager page)
        {
            IEnumerable<News> newslist;
            if (type != null && type.Value >= 0)
                newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective && n.NewsType == (NewsType)type, ns => ns.OrderByDescending(n => n.PublishTime), page);
            else
                newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective, ns => ns.OrderByDescending(n => n.PublishTime), page);
            var param = new Dictionary<string, object>();
            param["view"] = view;
            param["type"] = type;
            page.ParamObj = param;
            return View(view ?? "Index", new NewsListViewModel() { ListValue = newslist, Page = page, Type = type ?? -1 });
        }

        //[OutputCache(Duration = 60, VaryByParam = "type;index;size;view;israndom;")]
        public ActionResult GetPartialList(int? type, string view, Pager page, bool? isRandom = true)
        {
            if (isRandom.Value)
                page.Index = random.Next(0, 10);
            IEnumerable<News> newslist;
            if (type != null && type.Value >= 0)
                newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective && n.NewsType == (NewsType)type, ns => ns.OrderByDescending(n => n.PublishTime), page);
            else
                newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective, ns => ns.OrderByDescending(n => n.PublishTime), page);
            return PartialView(view, new NewsListViewModel() { ListValue = newslist, Page = page, Type = type ?? -1 });
        }

        public ActionResult GetLasterNews(string view, Pager page)
        {
            IEnumerable<News> newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective, ns => ns.OrderByDescending(n => n.PublishTime), page);
            return PartialView(view, new NewsListViewModel() { ListValue = newslist, Page = page, Type = -1 });
        }

        public ActionResult Details(int id)
        {
            var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, News>(new UpdateHitCmd() { Id = id, Type = SiteType.NEWS });
            if (domain == null || domain.Statue != DomainStatue.Effective)
                return HttpNotFound();
            return View(domain);
        }

        [OutputCache(Duration = 300, VaryByParam = "index;size;companyid;")]
        public ActionResult GetCompanyNews(int companyid, string view, Pager page)
        {
            IEnumerable<News> newslist = query.GetList<News>(n => n.Statue == DomainStatue.Effective && n.CompanyId == companyid && !string.IsNullOrEmpty(n.PictureUrl), ns => ns.OrderByDescending(n => n.PublishTime), page);
            return PartialView(view ?? "GetCompanyNews", new NewsListViewModel() { ListValue = newslist, Page = page, Type = -1 });
        }

        public ActionResult Create()
        {
            return View(new CreateNewsCmd() { RegUserId = 1 });
        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult PostCreate(CreateNewsCmd cmd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var domain = DefaultCommandBus.Instance.SendCommand<CreateNewsCmd, News>(cmd);
                    return RedirectToAction("details", new { id = domain.Id });
                }
            }
            catch (Exception ex)
            {

            }
            return View(cmd);
        }

        public ActionResult Edit(EditNewsCmd cmd)
        {
            var domain = query.Get<News>(cmd.Id);
            domain.DomainToEditCmd(cmd);
            return View(cmd);
        }

        [HttpPost]
        [ActionName("edit")]
        public ActionResult PostEdit(EditNewsCmd cmd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var domain = DefaultCommandBus.Instance.SendCommand<EditNewsCmd, News>(cmd);
                    return RedirectToAction("details", new { id = domain.Id });
                }
            }
            catch (Exception ex)
            {

            }
            return View(cmd);
        }

        //public ActionResult Delete(DeleteDomainCmd cmd)
        //{
        //    cmd.Type = SiteType.NEWS;
        //    DefaultCommandBus.Instance.SendCommand(cmd);
        //    return RedirectToAction("index");
        //}

        public ActionResult Rollback(RollbackDomainCmd cmd)
        {
            cmd.Type = SiteType.NEWS;
            DefaultCommandBus.Instance.SendCommand(cmd);
            return RedirectToAction("details", new { id = cmd.Id });
        }
    }
}
