using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EventLogger.Mvc.Controllers
{
    public class EventLogsController : BaseController
    {
        private IEventService _eventService;
        private int pageSize;
        private int recordsPerPage;
        private int TotalItemCount;


        public EventLogsController()
        {
            _eventService = new EventService();
            pageSize = 0;
            recordsPerPage = 5;
            TotalItemCount = 0;
        }


        public ActionResult Statistic()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionResult Index(int page=1, string term = "", SortOrder sortOrder= SortOrder.Desc, EventLogType eventLogType= EventLogType.Error)
        {

            var logs = _eventService.Search(eventLogType: eventLogType, page: page,recordsPerPage:recordsPerPage,term: term,  sortOrder: sortOrder, pageSize: out pageSize, TotalItemCount: out TotalItemCount);

            #region ViewBags

            ViewBag.EventLogType = EnumHelper.GetSelectList(type:typeof(EventLogType));
            ViewBag.SortOrder = EnumHelper.GetSelectList(typeof(SortOrder));
            ViewBag.CurrentEventLogType = eventLogType;
            ViewBag.Term = term;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = TotalItemCount;


            #endregion
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