namespace CoWorking.Contracts.Data.Query
{
    public class Includes<TEntity> where TEntity : class, IBaseEntity
    {
        public Includes(Func<IQueryable<TEntity>, IQueryable<TEntity>> expression)
        {
            Expression = expression;
        }

        public Func<IQueryable<TEntity>, IQueryable<TEntity>> Expression { get; private set; }
    }
}
