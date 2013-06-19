using GkwCn.Framework.Commands.Buses;
using GkwCn.Framework.Mvc;
using GkwCn.Models.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            var cmd = new GetSiteMapCmd();
            DefaultCommandBus.Instance.SendCommand(cmd);
            return View(cmd);
        }

        protected override void DisposeQueryService()
        {
            
        }
    }
}
