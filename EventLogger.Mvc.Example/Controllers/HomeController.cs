using System;
using System.Web;
using System.Web.Mvc;

namespace EventLogger.Mvc.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cookie = HttpContext.Request.Cookies["mycook"];
            if (cookie == null )
            {
                var httpCookie = new HttpCookie("mycook", "hamedi")
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Response.SetCookie(httpCookie);
            }

            //throw new Exception("test ex");
            return View(); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}