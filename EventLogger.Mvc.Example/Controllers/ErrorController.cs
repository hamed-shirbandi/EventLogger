using System;
using System.Web.Mvc;

namespace EventLogger.Mvc.Example.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View(); 
        }

        public ActionResult Unknown()
        {

            return View();
        }

    }
}