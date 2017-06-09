using EventLogger.Context;
using EventLogger.Migrations;
using System.Data.Entity;

namespace EventLogger.Mvc
{
    public class Config 
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
        public static void setDbInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainContext, Configuration>());
        }
        
    }
}