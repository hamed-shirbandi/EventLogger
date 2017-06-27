using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using RazorGenerator.Mvc;
using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace EventLogger.Mvc.Controllers
{
    public class EventLogsController : BaseController
    {
        private IEventService _eventService;

        public EventLogsController()
        {
            _eventService = new EventService();
        }


        /// <summary>
        /// 
        /// </summary>
        public ActionResult Index()
        {
            var logs = _eventService.Search(EventLogType.Error);
            return View(logs); 
        }


        /// <summary>
        /// 
        /// </summary>
        public ActionResult Details(int id)
        {
            var log = _eventService.Get(id);
            return View(log);
        }

    }
}