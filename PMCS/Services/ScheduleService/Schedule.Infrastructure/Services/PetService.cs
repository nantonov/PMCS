using IdentityModel.Client;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Models.Pets.Owner;

namespace Schedule.Infrastructure.Services
{
    public class PetService : IPetService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService _authService;

        public PetService(IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        public async Task<Owner> GetOwner(int userId)
        {
            var client = await GetAuthenticatedClient();

            var response = await client.GetAsync($"/api/owner/userId/{userId}");

            var result = await response.Content.ReadAsAsync<Owner>();

            return result;
        }

        private async Task<HttpClient> GetAuthenticatedClient()
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.PetClientName);

            var accessToken = await _authService.GetAccessToken(AuthConfiguration.PetScope);
            client.SetBearerToken(accessToken);

            return client;
        }
    }
}
