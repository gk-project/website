using GkwCn.Framework.Commands.Buses;
using GkwCn.Framework.Mvc;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Areas.Admin.Controllers
{
    public class SiteController : BaseController
    {
        //
        // GET: /Admin/Site/
        public ActionResult BuildSitemap(BuildSitemapCmd cmd)
        {
            DefaultCommandBus.Instance.SendCommand(cmd);
            return Content(cmd.Message);
        }


        protected override void DisposeQueryService()
        {
            
        }
    }
}
