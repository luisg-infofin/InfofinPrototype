using MassTransit;
using SearchService.Consumers;

namespace SearchService.Configurations
{
    public static class RabbitMQConfiguration
    {
        public static IServiceCollection AddRabbitMQConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumersFromNamespaceContaining<PersonCreatedConsumer>();


                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], "/", host =>
                    {
                        host.Username(configuration.GetValue("RabbitMQ:Username", "guest"));
                        host.Password(configuration.GetValue("RabbitMQ:Password", "guest"));
                    });

                    // List of consumers
                    cfg.ReceiveEndpoint("search-person-created", e =>
                    {
                        e.UseMessageRetry(r => r.Interval(5, 5));
                        e.ConfigureConsumer<PersonCreatedConsumer>(context);
                    });


                    cfg.ConfigureEndpoints(context);
                });

            });

            return services;
        }
    }
}
