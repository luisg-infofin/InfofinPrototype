using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await DB.Find<Item>().ExecuteAsync();
                return Ok(users);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
