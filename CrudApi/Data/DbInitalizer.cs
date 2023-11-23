using Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        // create scope to acces to the DbContext
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext ctx)
    {
        ctx.Database.Migrate();
        if (ctx.Users.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var users = new List<User>
        {
            new User
            {
                CreatedAt = DateTime.Now,
                CreationUser = "SYSTEM",
                Email = "alastorlml@gmail.com",
                Address = "Monterrey, Nuevo Leon",
                Name = "Luis"
            },
            new User
            {
                CreatedAt = DateTime.Now,
                CreationUser = "SYSTEM",
                Email = "valeria@gmail.com",
                Address = "Monterrey, Nuevo Leon",
                Name = "Arely"
            }
        };
       
        ctx.AddRange(users);
        ctx.SaveChanges();
    }
}
