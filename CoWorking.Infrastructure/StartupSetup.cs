using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Infrastructure.Data;
using CoWorking.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoWorking.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CoWorkingDbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void AddIdentityDbContext(this IServiceCollection services)
        {
            services.AddIdentity<User,
                IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CoWorkingDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
