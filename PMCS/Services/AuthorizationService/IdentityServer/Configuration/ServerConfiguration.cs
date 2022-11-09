using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer.Configuration
{
    public class ServerConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>()
            {
                new ApiScope("PetAPI", "Pets WebAPI"),
                new ApiScope("NotificationsAPI", "Notifications WebAPI"),
                new ApiScope("ScheduleAPI","Schedule WebAPI")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>()
            {
                new ApiResource("PetAPI"),
                new ApiResource("NotificationsAPI"),
                new ApiResource("ScheduleAPI")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>()
            {
                new Client()
                {
                   ClientId = "pmcs-client-id",
                   ClientSecrets = { new Secret("client_secret".ToSha256()) },
                   ClientName = "M2M Client",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                   AllowedScopes = {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       IdentityServerConstants.StandardScopes.Email,
                       "PetAPI",
                       "NotificationsAPI",
                       "ScheduleAPI"
                   }
                },
                new Client()
                {
                    ClientId = "swagger-client-id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    ClientName = "Swagger Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "PetAPI",
                        "NotificationsAPI",
                        "ScheduleAPI"
                    }
                },
                new Client()
                {
                    ClientId = "react-client-id",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,
                    ClientName = "React Client",
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    RedirectUris = { "http://localhost:3000/callback", "http://localhost:3000/refresh" },
                    PostLogoutRedirectUris = { "http://localhost:3000/logout" },
                    AllowedGrantTypes =  GrantTypes.Code,
                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "PetAPI",
                        "ScheduleAPI"
                    }
                }
            };
    }
}

