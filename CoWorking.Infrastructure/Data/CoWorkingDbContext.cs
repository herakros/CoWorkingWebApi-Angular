using Microsoft.EntityFrameworkCore;

namespace CoWorking.Infrastructure.Data
{
    public class CoWorkingDbContext : DbContext
    {
        public CoWorkingDbContext(DbContextOptions<CoWorkingDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
