using IdentityService.Models;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityService.Services
{
    public interface IJwtService
    {
        /// <summary>
        /// Create users session
        /// </summary>
        /// <param name="user">User to create a session</param>
        /// <returns>Session object</returns>
        Session CreateSession(AppUser user);

        /// <summary>
        /// Decode the token
        /// </summary>
        /// <param name="token">Token to be decoded</param>
        /// <returns>JwtSecurtyToken</returns>
        JwtSecurityToken DecodeToken(string token);
    }
}
