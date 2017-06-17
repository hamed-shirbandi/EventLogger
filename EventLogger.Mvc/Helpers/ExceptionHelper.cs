using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventLogger.Mvc
{
    public class ExceptionHelper
    {
        public static string GetRuteValues(ExceptionContext filterContext)
        {
            var keyValues = string.Empty;
            var keys = filterContext.RouteData.Values.Keys;
            var values = filterContext.RouteData.Values;

            foreach (var key in keys)
            {
                keyValues += key + " = " + values[key].ToString() + " , ";
            }

            return keyValues;
        }
    }
}
