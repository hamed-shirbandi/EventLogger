using System;
using System.Web.Mvc;

namespace EventLogger.Mvc.Controllers
{
    public class EventLogsController : Controller
    {


        public EventLogsController()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public ActionResult Index()
        {
            return View(); 
        }




        /// <summary>
        /// 
        /// </summary>
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}