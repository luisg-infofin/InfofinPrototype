using IdentityService.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Configurations
{
    public static class DbContextConfigurations
    {
        public static IServiceCollection AddDbPostgresContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefautlConnection"));
            });

            return services;
        }
    }
}
