using static PMCS.API.Tests.Entities.PetEntities;

namespace PMCS.API.Tests
{
    public class PetControllerTests : APIIntegrationTestsBase
    {
        [Fact]
        public async Task GetAll_PetsExist_ReturnsOwnersListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddRangeAsync(ValidPetEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Pet");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(await response.Content.ReadAsAsync<List<OwnerViewModel>>());
        }
    }
}
