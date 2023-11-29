using IdentityService.Models;
using IdentityService.Utils;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data
{
    public class DbInitializer
    {
        public static void InitializeDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            SeedDatabase(scope.ServiceProvider.GetRequiredService<AppDbContext>());
        }

        private static void SeedDatabase(AppDbContext context)
        {
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Count() > 0)
            {
                context.Database.Migrate();
            }

            if (!context.Users.Any())
            {
                EncryptHMAC.GetHMAC52("Pass123$", out byte[] alastorPassword, out byte[] alastorSalt);
                EncryptHMAC.GetHMAC52("Passw0rd", out byte[] jessicaPassword, out byte[] jessicaSalt);
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "alastor",
                        Email = "alastorlml@gmail.com",
                        Password = alastorPassword,
                        Salt = alastorSalt
                    },
                    new AppUser
                    {
                        UserName = "jessica",
                        Email = "jessy@gmail.com",
                        Password = jessicaPassword,
                        Salt = jessicaSalt
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
