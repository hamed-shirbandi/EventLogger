using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventLogger.Mvc.Example
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // initial event logger
            EventLoggerConfig.Init();

            // set log filters to automate logging
            GlobalFilters.Filters.Add(new EventLogFilter());
            GlobalFilters.Filters.Add(new ErrorLogFilter());


            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
        }
    }
}
