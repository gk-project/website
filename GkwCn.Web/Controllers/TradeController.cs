using GkwCn.Domains;
using GkwCn.Domains.Business;
using GkwCn.Framework.Commands.Buses;
using GkwCn.Framework.Mvc;
using GkwCn.Models.Commands;
using GkwCn.Models.Commands.Business;
using GkwCn.Models.Commands.Common;
using GkwCn.Models.ViewaModels;
using GkwCn.QueryService;
using GkwCn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Controllers
{
    public class TradeController : BaseController
    {
        TradeQueryService query = new TradeQueryService();

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }

        public ActionResult Create()
        {
            var cmd = new CreateTradeCmd();
            return View(cmd);
        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult PostCreate(CreateTradeCmd cmd)
        {
            var domain = DefaultCommandBus.Instance.SendCommand<CreateTradeCmd, Trade>(cmd);
            return RedirectToAction("details", new { id = domain.Id });
        }

        public ActionResult Edit(EditTradeCmd cmd)
        {
            var domain = query.Get<Trade>(cmd.Id);
            domain.DomainToEditCmd(cmd);
            return View(cmd);
        }

        [HttpPost]
        [ActionName("edit")]
        public ActionResult PostEdit(EditTradeCmd cmd)
        {
            cmd.IsEasy = false;
            var domain = DefaultCommandBus.Instance.SendCommand<EditTradeCmd, Trade>(cmd);
            return RedirectToAction("details", new { id = domain.Id });
        }

        public ActionResult Details(int id)
        {
            //var cmd = new BuildStaticPageCmd(HttpContext.Request.Url.Host) { Id = id, Type = SiteType.TRADE, BuildType = (BuildType)t };
            //if (cmd.BuildType != BuildType.NONE)
            //{
            //    var url = DefaultCommandBus.Instance.SendCommand<BuildStaticPageCmd, string>(cmd);
            //    if (string.IsNullOrEmpty(url))
            //        return HttpNotFound();
            //    Response.AddHeader("Location", url);
            //    return new HttpStatusCodeResult(301);
            //}
            //else
            //{
            //    var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, Trade>(new UpdateHitCmd() { Id = id, Type = SiteType.TRADE });
            //    if (domain == null || domain.Statue != DomainStatue.Effective)
            //        return HttpNotFound();
            //    return View(domain);
            //}
            var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, Trade>(new UpdateHitCmd() { Id = id, Type = SiteType.TRADE });
            if (domain == null || domain.Statue != DomainStatue.Effective)
                return HttpNotFound();
            return View(domain);
        }

        public ActionResult Delete(DeleteDomainCmd cmd)
        {
            cmd.Type = SiteType.TRADE;
            DefaultCommandBus.Instance.SendCommand(cmd);
            return RedirectToAction("index");
        }

        public ActionResult Rollback(RollbackDomainCmd cmd)
        {
            cmd.Type = SiteType.TRADE;
            DefaultCommandBus.Instance.SendCommand(cmd);
            return RedirectToAction("details", new { id = cmd.Id });
        }

        private static Random random = new Random(99999);
        //[OutputCache(Duration = 300, VaryByParam = "type;index;view;size;israndom;")]
        public ActionResult GetPartialList(string view, int? type, Pager page, bool? isRandom = true)
        {
            if (isRandom.Value)
                page.Index = random.Next(0, 100);
            IEnumerable<Trade> trades = null;
            if (type.IsNull() || !type.HasValue || type.Value < 0)
                trades = query.GetList<Trade>(p => p.Statue == DomainStatue.Effective, ps => ps.OrderByDescending(p => p.UpdateTime), page);
            else
                trades = query.GetList<Trade>(p => p.Statue == DomainStatue.Effective && p.TradeType == (TradeType)type.Value, ps => ps.OrderByDescending(p => p.UpdateTime), page);
            return PartialView(view ?? "GetPartialList", new TradeListViewModel() { Type = type ?? -1, ListValue = trades, Page = page });
        }

        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration = 300, VaryByParam = "type;index;size;")]
        public ActionResult List(int? type, Pager page)
        {
            IEnumerable<Trade> cooperates;
            if (type == null || !type.HasValue || type.Value < 0)
                cooperates = query.GetList<Trade>(o => o.Statue == DomainStatue.Effective, os => os.OrderByDescending(o => o.UpdateTime), page);
            else
                cooperates = query.GetList<Trade>(o => o.Statue == DomainStatue.Effective && o.TradeType == (TradeType)type.Value, os => os.OrderByDescending(o => o.UpdateTime), page);

            return View(new TradeListViewModel() { ListValue = cooperates, Page = page, Type = type ?? -1 });
        }
    }
}
