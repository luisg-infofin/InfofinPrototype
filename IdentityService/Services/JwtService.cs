using IdentityService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public Session CreateSession(AppUser user)
        {
            var timeToExpire = Convert.ToInt16(_config.GetValue("Jwt:ExpiresIn", "3"));
            var expiresInMilSeconds = DateTimeOffset.Now.AddHours(timeToExpire).ToUnixTimeMilliseconds().ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Symmetric Security Key
            var byteSymmetricSecurityKey = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(_config.GetValue("Jwt:SecurityKey", "UltraSecretKey234")));

            //Credentials
            var credentials = new SigningCredentials(byteSymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //ExpiresIn
            var expiresIn = DateTime.Now.AddHours(timeToExpire);

            //Payload
            var payload = new JwtSecurityToken(claims: claims, expires: expiresIn, signingCredentials: credentials, issuer: _config.GetValue("Jwt:Issuer", "http://localhost:5000"));
            var jwt = new JwtSecurityTokenHandler().WriteToken(payload);

            return new Session(expiresInMilSeconds, jwt);
        }

        public JwtSecurityToken DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(token);    
        }
    }
}
