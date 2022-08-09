using static PMCS.API.Tests.Entities.OwnerEntities;

namespace PMCS.API.Tests
{
    public class OwnerControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _appFactory;
        public OwnerControllerTests()
        {
            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<PMCS.DAL.AppContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<PMCS.DAL.AppContext>(options => options.UseInMemoryDatabase("Test_db"));
                }));

            _httpClient = _appFactory.CreateClient();
        }

        [Fact]
        public async Task GetAll_OwnersExist_ReturnsOwnersList()
        {
            await SeedDatabaseAsync();

            var response = await _httpClient.GetAsync("https://localhost:7104/api/Owner");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(await response.Content.ReadAsAsync<List<OwnerViewModel>>());
        }

        [Fact]
        public async Task GetAll_OwnersDoNotExist_ReturnsEmptyResponse()
        {
            var response = await _httpClient.GetAsync("https://localhost:7104/api/Owner");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(await response.Content.ReadAsAsync<List<OwnerViewModel>>());
        }

        private async Task SeedDatabaseAsync()
        {
            PMCS.DAL.AppContext context = _appFactory.Services.CreateScope().ServiceProvider.GetService<PMCS.DAL.AppContext>();

            await context.Owners.AddRangeAsync(ValidOwnerEntityList);
            await context.SaveChangesAsync();
        }
    }
}
