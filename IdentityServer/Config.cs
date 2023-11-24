using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("demoApp"),               
            };

        public static IEnumerable<ApiResource> ApiResources=>
            new ApiResource[]
            {
                new ApiResource("demoApp"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // postman client
                new Client
                {
                    ClientId = "postman",
                    ClientName = "postman",
                    AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    RedirectUris = {"https://www.getpostman.com/oauth2/callback"},
                    AllowedScopes = { "openid", "profile", "demoApp" }
                },

                // angular client
                new Client
                {
                    ClientId = "angular_app",
                    ClientName = "angular_app",                    
                    AllowedGrantTypes = { GrantType.Implicit },                   
                    RedirectUris = {"http://localhost:4200/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:4200/logout-callback"},
                    RequireClientSecret = false,
                    AllowOfflineAccess = true,
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    AllowAccessTokensViaBrowser = true,                         
                },
            
            };
    }
}
