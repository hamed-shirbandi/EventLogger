using EventLogger.Context;
using EventLogger.Migrations;
using System.Data.Entity;

namespace EventLogger
{
    public class EventLoggerConfig
    {



        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            setDbInitializer();

        }








        /// <summary>
        /// 
        /// </summary>
        private static void setDbInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventLoggerContext, Configuration>());
        }
        
    }
}