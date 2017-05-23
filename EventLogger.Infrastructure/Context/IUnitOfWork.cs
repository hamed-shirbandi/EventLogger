using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EventLogger.Infrastructure.Context
{
    public interface IUnitOfWork
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;//- TEntity به معنای entity type است. کلاس‌های موجودیت‌هایی که از طریق DbSetها در معرض دید EF قرار می‌گیرند، اینجا قابل استفاده خواهند شد.
        //DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;// برای ایجاد چنین حالتی db.Entry(post).State = EntityState.Modified;
        void MarkAsModified<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> ExecuteSqlCommandAsync(string query);
        int ExecuteSqlCommand(string query);
        IList<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void ForceDatabaseInitialize();
    }
}
