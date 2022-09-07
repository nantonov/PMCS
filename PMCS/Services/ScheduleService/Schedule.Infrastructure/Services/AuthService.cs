using IdentityModel.Client;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Services;

namespace Schedule.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessToken(string scope)
        {
            var authClient = _httpClientFactory.CreateClient(ClientsConfiguration.AuthClientName);
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync(ClientsConfiguration.AuthServiceAddress);

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,

                ClientId = AuthConfiguration.ClientId,
                ClientSecret = AuthConfiguration.ClientSecret,

                Scope = scope
            });

            return tokenResponse.AccessToken;
        }
    }
}
