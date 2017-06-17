using EventLogger.Mvc.Filters;
using System.Data.Entity.Infrastructure.Interception;
using System.Web;
using System.Web.Mvc;

namespace EventLogger.Mvc.Example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

        }
    }
}
