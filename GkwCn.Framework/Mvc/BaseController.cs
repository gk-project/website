using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GkwCn.Framework.Mvc
{
    public abstract class BaseController : Controller
    {
        protected override void Dispose(bool disposing)
        {
            DisposeQueryService();
            base.Dispose(disposing);
        }

        protected abstract void DisposeQueryService();
    }
}
