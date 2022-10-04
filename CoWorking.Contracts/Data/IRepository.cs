using System.Data.Entity;
using System.Linq.Expressions;

namespace CoWorking.Contracts.Data
{
    public interface IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByKeyAsync<TKey>(TKey key);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        Task AddRangeAsync(List<TEntity> entities);

        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByKeyWithIncludesAsync(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
    }
}
