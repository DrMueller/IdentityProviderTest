using System.Collections.Generic;
using IdentityServer4.Models;

namespace Mmu.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("Api", "My API"),
                new ApiResource("Api3", "My API"),
                new ApiResource
                {
                    Name = "CoolWepApi",
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "api.read",
                            DisplayName = "Read only access to the api"
                        },
                        new Scope
                        {
                            Name = "api.write",
                            DisplayName = "Full access to the calendar"
                        }
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    RequireConsent = false,
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api.write" }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };
    }
}