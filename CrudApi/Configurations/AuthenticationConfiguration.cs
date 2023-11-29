using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CrudApi.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     // To know who issued the token
                     options.Authority = configuration["IdentityUrl"];
                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters.ValidateAudience = false;                     
                 });

            return services;
        }
    }
}
