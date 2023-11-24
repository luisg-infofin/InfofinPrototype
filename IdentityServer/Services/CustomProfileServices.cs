using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Services
{
    public class CustomProfileServices : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomProfileServices(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            var existingClaims = await _userManager.GetClaimsAsync(user);
            
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("test", "Esta es una claim de prueba")
            };

            context.IssuedClaims.AddRange(claims);
            context.IssuedClaims.Add(existingClaims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
