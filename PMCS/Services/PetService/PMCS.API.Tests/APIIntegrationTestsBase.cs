using Microsoft.AspNetCore.Authorization.Policy;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace PMCS.API.Tests
{
    public class APIIntegrationTestsBase : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly WebApplicationFactory<Program> _appFactory;
        protected DAL.AppContext _context;

        protected APIIntegrationTestsBase()
        {
            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<PMCS.DAL.AppContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<PMCS.DAL.AppContext>(options => options.UseInMemoryDatabase("Test_db"));
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                }));

            _httpClient = _appFactory.CreateClient();
            _context = _appFactory.Services.CreateScope().ServiceProvider.GetService<PMCS.DAL.AppContext>();
        }

        protected HttpContent SerializeObjectToHttpContent(object objectToParse)
        {
            string jsonString = JsonConvert.SerializeObject(objectToParse);

            ByteArrayContent content = new StringContent(jsonString);

            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);

            return content;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
