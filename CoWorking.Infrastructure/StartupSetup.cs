using CoWorking.Contracts.Data;
using CoWorking.Infrastructure.Data;
using CoWorking.Infrastructure.Data.Repositories;
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
    }
}
