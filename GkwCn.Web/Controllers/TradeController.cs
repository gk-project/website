using GkwCn.Domains.Business;
using GkwCn.Framework.Commands.Buses;
using GkwCn.Framework.Mvc;
using GkwCn.Models.Commands.Business;
using GkwCn.QueryService;
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
    }
}
