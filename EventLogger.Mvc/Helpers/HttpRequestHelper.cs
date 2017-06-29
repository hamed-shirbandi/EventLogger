using System.Web;
using System.Web.Routing;

namespace EventLogger.Mvc
{
   public class HttpRequestHelper
    {
        public static string GetCurrentUserName(HttpContextBase context)
        {
            return context.User.Identity.Name;

        }
        public static string GetQueryString(HttpContextBase context)
        {
            return context.Request.Url.Query;

        }
        public static string GetUrl(HttpContextBase context)
        {
            return context.Request.Url.AbsolutePath;

        }
        public static string GetUserAgent(HttpContextBase context)
        {
            return context.Request.UserAgent;

        }
        public static string GetIpAddress(HttpContextBase context)
        {
            return context.Request.UserHostAddress;

        }
        public static string GetPathInfo(HttpContextBase context)
        {
            return context.Request.PathInfo;

        }
        public static string GetRuteValues(RouteData routeData)
        {
            var keyValues = string.Empty;
            var keys = routeData.Values.Keys;
            var values = routeData.Values;

            foreach (var key in keys)
            {
                keyValues += key + " = " + values[key].ToString() + " , ";
            }

            return keyValues;
        }
        public static string GetControllerName(RouteData routeData)
        {
           return routeData.Values["controller"].ToString();
        }
        public static string GetActionName(RouteData routeData)
        {
            return routeData.Values["action"].ToString();

        }

    }
}
