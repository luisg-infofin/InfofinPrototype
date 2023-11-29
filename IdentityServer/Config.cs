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
                new ApiResource("demoApp", "Demo App")
                {
                    Scopes = {"demoApp"}
                },
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration){
            return new Client[]
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
                    ClientId = configuration["AngularClient:ClientId"],
                    ClientName = configuration["AngularClient:ClientId"],                    
                    AllowedGrantTypes = { GrantType.Implicit },                   
                    RedirectUris = {configuration["AngularClient:RedirectUri"]},
                    PostLogoutRedirectUris = {configuration["AngularClient:PostlogutUri"]},
                    RequireClientSecret = false,                    
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    AllowAccessTokensViaBrowser = true,                         
                },

                // blazor client
                new Client
                {
                    ClientId = configuration["BlazorClient:ClientId"],
                    //ClientName = configuration["BlazorClient:ClientId"],
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = true,
                    RedirectUris = {configuration["BlazorClient:RedirectUri"]},
                    PostLogoutRedirectUris = {configuration["BlazorClient:PostlogutUri"]},
                    RequireClientSecret = false,                    
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, "demoApp" },                                        
                },     
            };
        }            
    }
}
