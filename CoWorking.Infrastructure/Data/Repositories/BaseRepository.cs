using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CoWorking.Contracts.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoWorking.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly CoWorkingDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(CoWorkingDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByKeyAsync<TKey>(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Modified);
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, 
                IQueryable<TEntity>>(_dbSet, (current, include) => current.Include(include));

            return query;
        }
    }
}
