using IdentityModel.Client;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Models.Pets.Meal;
using Schedule.Application.Core.Models.Pets.Owner;
using Schedule.Application.Core.Models.Pets.Vaccine;
using Schedule.Application.Core.Models.Pets.Walking;
using Schedule.Application.Helpers;

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

        public async Task<Meal> AddMeal(PostMealRequest request)
        {
            var client = await GetAuthenticatedClient();

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await client.PostAsync("/api/meal", content);

            var result = await response.Content.ReadAsAsync<Meal>();

            return result;
        }

        public async Task<Walking> AddWalking(PostWalkingRequest request)
        {
            var client = await GetAuthenticatedClient();

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await client.PostAsync("/api/walking", content);

            var result = await response.Content.ReadAsAsync<Walking>();

            return result;
        }

        public async Task<Vaccine> AddVaccine(PostVaccineRequest request)
        {
            var client = await GetAuthenticatedClient();

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await client.PostAsync("/api/vaccine", content);

            var result = await response.Content.ReadAsAsync<Vaccine>();

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
