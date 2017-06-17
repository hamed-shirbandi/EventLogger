using System;
using System.Linq;

namespace EventLogger.Mvc
{
    internal class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        private readonly string[] allowedUsers;

        private readonly bool isHandlerDisabled;
        private readonly bool requiresAuthentication;

        public AuthorizeAttribute()
        {
            //this.allowedRoles = Settings.AllowedRoles.Split(',')
            //                .Where(r => !string.IsNullOrWhiteSpace(r))
            //                .Select(r => r.Trim())
            //                .ToArray();

            //this.allowedUsers = Settings.AllowedUsers.Split(',')
            //                        .Where(r => !string.IsNullOrWhiteSpace(r))
            //                        .Select(r => r.Trim())
            //                        .ToArray();

            //this.isHandlerDisabled = Settings.DisableHandler;
            //this.requiresAuthentication = Settings.RequiresAuthentication;
        }

        //protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        //{
        //    return !this.isHandlerDisabled && (!this.requiresAuthentication || this.UserIsAllowed(httpContext));
        //}

        /// <summary>
        /// Check that current user is in allowed roles AND in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowed(System.Web.HttpContextBase httpContext)
        {

            return this.UserIsAllowedByRole(httpContext) && this.UserIsAllowedByName(httpContext);
        }

        /// <summary>
        /// Check that current user is  in allowed roles
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByRole(System.Web.HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated &&
                   (this.allowedRoles.Any(r => r == "*" || httpContext.User.IsInRole(r)));
        }

        /// <summary>
        /// Check that user is in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByName(System.Web.HttpContextBase httpContext)
        {
            return true;
            //var stringComparison = Settings.UserAuthCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            //return httpContext.Request.IsAuthenticated &&
            //      (this.allowedUsers.Any(u => u == "*" || u.Equals(httpContext.User.Identity.Name, stringComparison)));
        }
    }
}