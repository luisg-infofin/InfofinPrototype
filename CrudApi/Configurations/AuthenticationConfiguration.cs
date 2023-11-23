using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CrudApi.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, string tokenAuthority)
        {            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     // To know who issued the token
                     options.Authority = tokenAuthority;
                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters.ValidateAudience = false;
                     options.TokenValidationParameters.NameClaimType = "username";
                 });

            return services;
        }
    }
}
