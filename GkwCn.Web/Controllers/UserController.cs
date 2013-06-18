using GkwCn.Framework.Commands.Buses;
using GkwCn.Service;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GkwCn.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            using (var query = new RegUserQueryService())
            {
                var users = query.GetActionyRegUsers();
                return View(users);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterCmd model)
        {
            DefaultCommandBus.Instance.SendCommand(model);

            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword(int id)
        {
            var query = new RegUserQueryService();
            var user = query.GetUserById(id);
            return View(new ChangePasswordCmd(user.Id, user.LoginName, string.Empty, string.Empty, string.Empty));
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordCmd model)
        {
            DefaultCommandBus.Instance.SendCommand(model);

            return RedirectToAction("Index");
        }
    }
}
