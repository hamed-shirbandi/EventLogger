using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EventLogger.Core.Domain;
using System.Configuration;

namespace EventLogger.Infrastructure.Context
{

    public class MainContext : DbContext, IUnitOfWork
    {

        static string con = ConfigurationManager.AppSettings["EventLoggerConnectionStringName"].ToString();
       
        #region Ctor

        public MainContext() : base(con)
        {
         
        }

        #endregion

        #region Properties

        public DbSet<Error> Errors { get; set; }
        public DbSet<Event> Events { get; set; }

        #endregion

        #region IUnitOfWork Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();

        }

        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Modified;

        }

        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Deleted;

        }

        public async Task<int> ExecuteSqlCommandAsync(string query)
        {
            return await base.Database.ExecuteSqlCommandAsync(query);
        }

        public int ExecuteSqlCommand(string query)
        {
            return base.Database.ExecuteSqlCommand(query);

        }

        public IList<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return this.Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return ((DbSet<TEntity>)this.Set<TEntity>()).AddRange(entities);
        }
        #endregion

        #region override Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<User>().ToTable("Users");

            // Configurations
            //modelBuilder.Configurations.Add(new CarMapping());


        }


        /// <summary>
        /// 
        /// </summary>
        public override Task<int> SaveChangesAsync()
        {
            try
            {
                return base.SaveChangesAsync();
            }
            //ثبت خطاهای مربوط به پراپرتی EntityValidationErrors
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            //ثبت خطاهای مربوط به پراپرتی EntityValidationErrors
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
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
