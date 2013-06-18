using GkwCn.Framework.Mvc;
using GkwCn.QueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Controllers
{
    public class ProvinceCityController : BaseController
    {
        ProvinceCityQueryService query = new ProvinceCityQueryService();

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }

        public ActionResult GetCity(string pname)
        {
            var citys = query.GetCitys(pname);
            return Json(citys.Select(o => new { id = o.Id, text = o.Name }),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProvince()
        {
            var provinces = query.GetProvinces();
            return Json(provinces.Select(o => new { id = o.Id, text = o.Name }),JsonRequestBehavior.AllowGet);
        }
    }
}
