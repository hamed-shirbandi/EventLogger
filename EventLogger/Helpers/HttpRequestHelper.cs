using EventLogger.Service.EventLogs.Dto;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;

namespace EventLogger
{
   public class HttpRequestHelper
    {
        public static EventLogInput GetHttpRequestInfo(HttpContextBase httpContext, RouteData routeData)
        {
            var request = httpContext.Request;

            return new EventLogInput
            {
                Action = GetActionName(routeData),
                Controller = GetControllerName(routeData),
                RouteValues = GetRuteValues(routeData),
                UserName = GetCurrentUserName(httpContext),
                QueryString = GetQueryString(request),
                Url = GetUrl(request),
                UserAgent = GetUserAgent(request),
                Ip = GetIpAddress(request),
                PathInfo = GetPathInfo(request),
                UserHostName = GetUserHostName(request),
                PhysicalPath = GetPhysicalPath(request),
                PhysicalApplicationPath = GetPhysicalApplicationPath(request),
                MachineName = GetMachineName(request),
                Cookies = GetCookies(request),
                ServerVariables = GetServerVariables(request),
                Form = GetForm(request),
                HttpMethod = GetHttpMethod(request),
                Protocol = GetProtocol(request),
                Port = GetPort(request),
                HttpHost = GetHttpHost(request),
                UrlReferer = GetUrlReferer(request),
            };
        }

        public static string GetCookies(HttpRequestBase request)
        {
            return string.Empty;
        }
        public static string GetHttpMethod(HttpRequestBase request)
        {
            return request.HttpMethod;

        }
        public static string GetUrlReferer(HttpRequestBase request)
        {
            return request.UrlReferrer != null ? request.UrlReferrer.ToString() : string.Empty;
        }
        public static string GetProtocol(HttpRequestBase request)
        {
            return request.Url.Scheme ;

        }
        public static string GetPort(HttpRequestBase request)
        {
            return request.Url.Port.ToString();

        }
        public static string GetHttpHost(HttpRequestBase request)
        {
            return request.Url.Host;

        }
        public static string GetServerVariables(HttpRequestBase request)
        {
            return string.Empty;

        }
        public static string GetForm(HttpRequestBase request)
        {
            
            return string.Empty;

        }
        public static string GetUserHostName(HttpRequestBase request)
        {
            return request.UserHostName;

        }
        public static string GetPhysicalPath(HttpRequestBase request)
        {
            try
            {
                return request.PhysicalPath;
            }
            catch
            {
            }
            return string.Empty;

        }
        public static string GetPhysicalApplicationPath(HttpRequestBase request)
        {
            return request.PhysicalApplicationPath;

        }
        public static string GetMachineName(HttpRequestBase request)
        {
            var machineName = string.Empty;

            try
            {
                machineName = Environment.MachineName;
            }
            catch
            {
            }
            return machineName;
        }
        public static string GetCurrentUserName(HttpContextBase context)
        {
            if (context.User != null)
            {
                return context.User.Identity.Name;
            }
            return string.Empty;

        }
        public static string GetQueryString(HttpRequestBase request)
        {
            return request.Url.Query;

        }
        public static string GetUrl(HttpRequestBase request)
        {
            return request.RawUrl;

        }
        public static string GetUserAgent(HttpRequestBase request)
        {
            return request.UserAgent;

        }
        public static string GetIpAddress(HttpRequestBase request)
        {
            return request.UserHostAddress;

        }
        public static string GetPathInfo(HttpRequestBase request)
        {
            return request.PathInfo;

        }
        public static string GetRuteValues(RouteData routeData)
        {
            if (routeData==null)
                return string.Empty;
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
            if (routeData == null)
                return string.Empty;
            return routeData.Values["controller"].ToString();
        }
        public static string GetActionName(RouteData routeData)
        {
            if (routeData == null)
                return string.Empty;
            return routeData.Values["action"].ToString();

        }

    }
}
