using System.Data.Entity;
using System.Threading.Tasks;
using EventLogger.Domain;
using System.Configuration;

namespace EventLogger.Context
{

    public class EventLoggerContext : DbContext
    {

        static string con = ConfigurationManager.AppSettings["EventLoggerConnectionStringName"].ToString();

        #region Ctor

        public EventLoggerContext() : base(con)
        {
         
        }

        #endregion

        #region Properties

        public DbSet<EventLog> EventLogs { get; set; }

        #endregion


        #region override Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// 
        /// </summary>
        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }




        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void ForceDatabaseInitialize()
        {
            this.Database.Initialize(force: true);
        }



        #endregion

    }
}
