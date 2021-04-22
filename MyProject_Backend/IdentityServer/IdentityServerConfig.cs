using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MyProject_Backend.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("rookieshop.api", "Rookie Shop API")
             };
        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "rookieshop.api" }
                },

               // interactive ASP.NET Core MVC client

                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://leduyenweb.azurewebsites.net/signin-oidc" },

                    PostLogoutRedirectUris = { "https://leduyenweb.azurewebsites.net/signout-callback-oidc" },
                      
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api"
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { $"https://leduyenshop.azurewebsites.net/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"https://leduyenshop.azurewebsites.net/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"https://leduyenshop.azurewebsites.net" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api"
                    }
                },
            };
    }
}
