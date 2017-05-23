namespace EventLogger.Infrastructure.Migrations
{
    using Context;
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MainContext context)
        {

            context.SaveChanges();
        }
    }

}
