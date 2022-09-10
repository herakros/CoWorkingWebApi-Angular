using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CoWorking.Contracts.Data;
using Microsoft.EntityFrameworkCore;

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
            await Task.Run(() => _dbSet.Remove(entity));
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

        public async Task<TEntity> GetFirstBySpecAsync(ISpecification<TEntity> specification)
        {
            var res = await ApplySpecification(specification).FirstOrDefaultAsync();
            return res;
        }

        public async Task<IEnumerable<TReturn>> GetListBySpecAsync<TReturn>(ISpecification<TEntity, TReturn> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Modified);
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbSet, specification);
        }

        private IQueryable<TReturn> ApplySpecification<TReturn>(ISpecification<TEntity, TReturn> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbSet, specification);
        }
    }
}
