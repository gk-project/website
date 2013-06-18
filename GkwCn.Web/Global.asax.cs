using GkwCn.Web.Data;
using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GkwCn.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            InitialzeFramework();
        }

        private void InitialzeFramework()
        {
            GkwCnEnvironment.Configure(env =>
            {
                env.RegisterHandlers(Assembly.Load("GkwCn.Logic"))
                    .RegisterHandlers(Assembly.Load("GkwCn.Web"))
                   .RegisterUnitOfWorkFactory(() => new EFUnitOfWork(new GkwCnDbContext()));
            });
        }
    }
}