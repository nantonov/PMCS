using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Services;
using System.Security.Claims;

namespace Schedule.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _context;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor context)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            ArgumentNullException.ThrowIfNull(context);

            _httpClientFactory = httpClientFactory;
            _context = context;
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

        public async Task<IEnumerable<Claim>> GetUserClaims()
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.AuthClientName);
            var discoveryDocument = await client.GetDiscoveryDocumentAsync(ClientsConfiguration.AuthServiceAddress);

            var token = _context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").
                Value.SingleOrDefault()?.Replace("Bearer ", "");

            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = discoveryDocument.UserInfoEndpoint,
                Token = token
            });

            return response.Claims;
        }

    }
}

