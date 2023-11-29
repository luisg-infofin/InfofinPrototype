using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services
{
    public class UsersServiceHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public UsersServiceHttpClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetUsersForSearch() {
            var lastUpdated = await DB.Find<Item, string>()
                .Sort(x => x.Descending(p => p.UpdateAt))
                .Project(x => x.UpdateAt.ToString())
                .ExecuteFirstAsync();

            return await _httpClient.GetFromJsonAsync<List<Item>>(_configuration["CrudServiceUrl"] + "/api/users?date=" + lastUpdated);
        }

    }
}
