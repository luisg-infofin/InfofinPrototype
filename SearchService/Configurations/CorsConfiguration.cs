namespace SearchService.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddAngularCors(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AppClientsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:4200", "http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            return services;
        }
    }
}
