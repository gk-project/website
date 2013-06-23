using GkwCn.Domains;
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
    public class CompanyController : BaseController
    {
        private static Random random = new Random(99999);
        CompanyQueryService query = new CompanyQueryService();

        protected override void DisposeQueryService()
        {
            query.Dispose();
        }

        [OutputCache(Duration = 300, VaryByParam = "index;size;")]
        public ActionResult Index(Pager page)
        {
            var companys = query.GetList<Company>(o => o.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(o.Logo), cs => cs.OrderByDescending(c => c.Hit), page);
            return View(new CompanyListViewModel() { ListValue = companys, Page = page });
        }

        //[OutputCache(Duration = 300, VaryByParam = "index;size;view;israndom")]
        public ActionResult GetPartialList(string view, Pager page, bool? isRandom = true)
        {
            if (isRandom.Value)
                page.Index = random.Next(0, 200);
            var companys = query.GetList<Company>(o => o.Statue == DomainStatue.Effective && !string.IsNullOrEmpty(o.Logo), cs => cs.OrderByDescending(c => c.Hit), page);
            return PartialView(view ?? "GetPartialList", new CompanyListViewModel() { ListValue = companys, Page = page });
        }

        public ActionResult Details(int id)
        {
            var domain = DefaultCommandBus.Instance.SendCommand<UpdateHitCmd, Company>(new UpdateHitCmd() { Id = id, Type = SiteType.COMPANY });
            if (domain == null || domain.Statue != DomainStatue.Effective)
                return HttpNotFound();
            return View(domain);
        }

        public ActionResult Create()
        {
            return View(new CreateCompanyCmd() { RegUserId = 1 });
        }

        [HttpPost]
        [ActionName("create")]
        public ActionResult PostCreate(CreateCompanyCmd cmd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var domain = DefaultCommandBus.Instance.SendCommand<CreateCompanyCmd, Company>(cmd);
                    return RedirectToAction("details", new { id = domain.Id });
                }
            }
            catch (Exception ex)
            {

            }
            return View(cmd);
        }

        public ActionResult Edit(EditCompanyCmd cmd)
        {
            var domain = query.Get<Company>(cmd.Id);
            domain.DomainToEditCmd(cmd);
            return View(cmd);
        }

        [HttpPost]
        [ActionName("edit")]
        public ActionResult PostEdit(EditCompanyCmd cmd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var domain = DefaultCommandBus.Instance.SendCommand<EditCompanyCmd, Company>(cmd);
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
        //    cmd.Type = SiteType.COMPANY;
        //    DefaultCommandBus.Instance.SendCommand(cmd);
        //    return RedirectToAction("index");
        //}

        public ActionResult Rollback(RollbackDomainCmd cmd)
        {
            cmd.Type = SiteType.COMPANY;
            DefaultCommandBus.Instance.SendCommand(cmd);
            return RedirectToAction("details", new { id = cmd.Id });
        }
    }
}
