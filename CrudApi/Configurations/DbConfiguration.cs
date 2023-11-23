using CrudApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Configurations
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(connectionString));

            return services;
        }
    }
}
