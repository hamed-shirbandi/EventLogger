using System.Configuration;

namespace EventLogger
{
    internal class Settings
    {
        public static string AllowedRoles
        {
            get
            {
                return ConfigurationManager.AppSettings["elmah.mvc.allowedRoles"] ?? "*";
            }
        }

        public static bool DisableHandleErrorFilter
        {
            get
            {
                return GetBoolValue("elmah.mvc.disableHandleErrorFilter", false);
            }
        }

        private static bool GetBoolValue(string key, bool defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
            {
                return defaultValue;
            }

            bool returnValue;

            if (!bool.TryParse(value, out returnValue))
            {
                return defaultValue;
            }

            return returnValue;
        }

    }
}
