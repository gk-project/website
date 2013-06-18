using GkwCn.Framework.Mvc;
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

            return View();
        }
    }
}
