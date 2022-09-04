using CoWorking.Contracts.Data.Entities.RefreshTokenEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoWorking.Infrastructure.Data
{
    public class CoWorkingDbContext : IdentityDbContext<User>
    {
        public CoWorkingDbContext(DbContextOptions<CoWorkingDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
