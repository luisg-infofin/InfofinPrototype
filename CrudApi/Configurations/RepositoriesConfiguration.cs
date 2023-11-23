using CrudApi.Contracts;
using CrudApi.Repositories;

namespace CrudApi.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IAbstractRepository<>), typeof(AbstractRepository<>));

            return services;
        }
    }
}
