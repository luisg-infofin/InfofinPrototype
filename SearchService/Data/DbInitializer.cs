using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Services;

namespace SearchService.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            // Initialize MongoDB
            await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

            using var scope = app.Services.CreateScope();
            var httpClient = scope.ServiceProvider.GetRequiredService<UsersServiceHttpClient>();
                        
            var items = await httpClient.GetUsersForSearch();            
            if (items.Count > 0) await DB.SaveAsync(items);
        }
    }
}
