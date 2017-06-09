using EventLogger.Context;
using System.Data.Entity.Migrations;

namespace EventLogger.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MainContext context)
        {
           
        }
    }
}
