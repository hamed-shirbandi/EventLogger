using EventLogger.Infrastructure.Context;
using EventLogger.Infrastructure.Migrations;
using EventLogger.Mvc.IocConfig;
using StructureMap.Web.Pipeline;
using System.Data.Entity;

namespace EventLogger.Mvc
{
    public class Config 
    {



        /// <summary>
        /// 
        /// </summary>
        public static void AppStart()
        {
            setDbInitializer();

        }




        /// <summary>
        /// 
        /// </summary>
        public static void IocDisposeAndClearAll()
        {
            HttpContextLifecycle.DisposeAndClearAll();

        }






        /// <summary>
        /// 
        /// </summary>
        public static void setDbInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainContext, Configuration>());
            EventLoggerSmObjectFactory.Container.GetInstance<IUnitOfWork>().ForceDatabaseInitialize();
        }
        
    }
}