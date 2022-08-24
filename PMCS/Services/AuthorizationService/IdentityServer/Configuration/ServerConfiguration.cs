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
                new ApiScope("PetApi", "Pets WebAPI"),
                new ApiScope("NotificationsApi", "Notifications WebAPI")
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
                new ApiResource("PetApi"),
                new ApiResource("NotificationsApi")
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
                       "NotificationsAPI"
                   }
                }
            };
    }
}

