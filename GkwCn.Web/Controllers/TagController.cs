using GkwCn.Framework.Utils;
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
    public class TagController : Controller
    {
        TagQueryService query = new TagQueryService();

        [OutputCache(Duration = 7200, VaryByParam = "keyword;type;index;size;")]
        public ActionResult GetPartialListByKeyword(string keyword, TagType type, Pager page)
        {
            var list = query.GetListByKeyword(keyword, type, page);
            return PartialView("GetPartialListByKeyword", list);
        }

        [OutputCache(Duration = 7200, VaryByParam = "keyword;type;index;size;")]
        public ActionResult GetListByKeyword(string keyword, TagType type, Pager page)
        {
            var list = query.GetListByKeyword(keyword, type, page);
            return View(list);
        }

        [OutputCache(Duration = 72000, VaryByParam = "keyword;")]
        public ActionResult Index(string keyword)
        {
            return View("Index", (object)keyword);
        }

        [OutputCache(Duration = 72000, VaryByParam = "keywords;")]
        public ActionResult TagBarByKeywords(string keywords)
        {
            if (keywords.IsNull())
                keywords = string.Empty;
            var keys = keywords.Replace(",", " ").Replace("，", " ").Replace("\r", " ").Replace("\n", " ").Replace("、"," ").Replace("||", " ").Split(' ').Select(o => o.Trim()).Where(o => !o.IsNullOrEmpty());
            return PartialView(keys);
        }
    }
}
