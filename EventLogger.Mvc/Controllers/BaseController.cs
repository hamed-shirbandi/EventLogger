using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using RazorGenerator.Mvc;
using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace EventLogger.Mvc.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {

        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            RegisterRazorGeneratorEngine();

            return base.BeginExecuteCore(callback, state);
        }


        private void RegisterRazorGeneratorEngine()
        {
            var engine = new PrecompiledMvcEngine(typeof(BaseController).Assembly)
            {
                //UsePhysicalViewsIfNewer = HttpContext.Current.Request.IsLocal
            };

            ViewEngines.Engines.Insert(0, engine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }


    }
}