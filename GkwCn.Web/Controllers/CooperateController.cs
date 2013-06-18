using System;
using System.Web.Mvc;
using GkwCn.Domains.Business;
using GkwCn.Framework.Mvc;
using GkwCn.QueryService;
using GkwCn.Models.ViewModels;
using GkwCn.Domains;
using GkwCn.Web.Models;
using System.Linq;
using System.Collections.Generic;
using GkwCn.Framework.Commands.Buses;
using GkwCn.Models.Commands;

namespace GkwCn.Web.Controllers
{
    /// <summary>
    /// Description of CooperateController.
    /// </summary>
    public class CooperateController : BaseController
    {
        private static Random random = new Random(99999);
        CooperateQueryService query = new CooperateQueryService();

        public ActionResult Index()
        {
            return View();
        }
        
        [OutputCache(Duration = 300, VaryByParam = "type;index;size;")]
        public ActionResult List(int? type, Pager page)
        {
            IEnumerable<Cooperate> cooperates;
            if (type == null || !type.HasValue || type.Value < 0)
                cooperates = query.GetList<Cooperate>(o => o.Statue == DomainStatue.Effective , os => os.OrderByDescending(o => o.CreateTime), page);
            else
                cooperates = query.GetList<Cooperate>(o => o.Statue == DomainStatue.Effective && (int)o.Type == type.Value , os => os.OrderByDescending(o => o.CreateTime), page);

            return View(new CooperateListViewModel() { ListValue = cooperates, Page = page });
        }

        [OutputCache(Duration = 300, VaryByParam = "type;index;size;view;israndom")]
        public ActionResult GetPartialList(int? type,string view, Pager page, bool? isRandom = false)
        {
            IEnumerable<Cooperate> cooperates;
            if (isRandom.Value)
                page.Index = random.Next(0, 10);
            if (type == null || !type.HasValue || type.Value < 0)
                cooperates = query.GetList<Cooperate>(o => o.Statue == DomainStatue.Effective, os => os.OrderByDescending(o => o.CreateTime), page);
            else
                cooperates = query.GetList<Cooperate>(o => o.Statue == DomainStatue.Effective && (int)o.Type == type.Value, os => os.OrderByDescending(o => o.CreateTime), page);

            return PartialView(view ?? "GetPartialList", new CooperateListViewModel() { ListValue = cooperates, Page = page });
        }

        public ActionResult Details(int id)
        {
            var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, Cooperate>(new UpdateHitCmd() { Id = id, Type = SiteType.COOPERATE });
            return View(domain);
        }

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }
    }
}