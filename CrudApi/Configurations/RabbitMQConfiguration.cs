using CrudApi.Data;
using MassTransit;

namespace CrudApi.Configurations
{
    public static class RabbitMQConfiguration
    {
        public static IServiceCollection AddRabbitMQConfig(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddMassTransit(x =>
            {

                //TODO: Add outbox configuration
                //x.AddEntityFrameworkOutbox<AppDbContext>(o =>
                //{
                //    o.UseOracle();
                //});

                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("person", false));

                //Rabbit MQ Configuration
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], "/", host =>
                    {
                        host.Username(configuration.GetValue("RabbitMQ:Username", "guest"));
                        host.Password(configuration.GetValue("RabbitMQ:Password", "guest"));
                    });

                    cfg.ConfigureEndpoints(context);
                });

            });

            return services;
        }
    }
}
