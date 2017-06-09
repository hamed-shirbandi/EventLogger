using EventLogger.Context;
using System.Data.Entity.Migrations;

namespace EventLogger.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EventLoggerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventLoggerContext context)
        {
           
        }
    }
}
