using IdentityService.Data;
using IdentityService.Models;
using IdentityService.Models.Dto;
using IdentityService.Services;
using IdentityService.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IJwtService _jwtService;

        public AuthController(AppDbContext context, IJwtService jwtService)
        {
            _dbContext = context;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto loginArgs)
        {
            try
            {
                // Look if user exists
                var user = await _dbContext.Users.FindAsync(loginArgs.UserName);
                if (user is null) throw new Exception("Usuario no encontrado");

                // if user exists, encyrpt password and get salt
                var isValidPassword = EncryptHMAC.CompareHMAC512(loginArgs.Password, user.Password, user.Salt);
                if(!isValidPassword) throw new Exception("Credenciales inválidas");

                // if is valid, generate token
                var session = _jwtService.CreateSession(user);
                return Ok(new ApiResponse { IsSuccess = true, Message = "Session created", StatusCode = 200, Data = session });
            }
            catch(Exception ex)
            {
                return Ok(new ApiResponse { IsSuccess = false, Message = "Usuario no encontrado", StatusCode = 500 });
            }
        }
    }
}
