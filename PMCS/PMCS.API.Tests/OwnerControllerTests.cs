using PMCS.API.Tests.ViewModels;
using static PMCS.API.Tests.Entities.OwnerEntities;

namespace PMCS.API.Tests
{
    public class OwnerControllerTests : APIIntegrationTestsBase
    {
        [Fact]
        public async Task GetAll_OwnersExist_ReturnsOwnersListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddRangeAsync(ValidOwnerEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Owner");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(await response.Content.ReadAsAsync<List<OwnerViewModel>>());
        }

        [Fact]
        public async Task GetById_OwnerExists_ReturnsOwnerWithOKStatusCode()
        {
            await _context.Owners.AddAsync(ValidOwnerEntity);
            await _context.AddRangeAsync();

            var response = await _httpClient.GetAsync("/api/Owner/1");

            var expected = ValidOwnerEntityList.FirstOrDefault(x => x.Id == 1);
            var actual = await response.Content.ReadAsAsync<OwnerViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async Task GetById_OwnerWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.GetAsync($"/api/Owner/{OwnerEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_OwnerExists_DeletesOwnerAndReturnsOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddAsync(ValidOwnerEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Owner/{ValidOwnerEntity.Id}");

            var getResponse = await _httpClient.GetAsync("/api/Owner");

            var actual = await getResponse.Content.ReadAsAsync<List<OwnerViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task Delete_OwnerWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.DeleteAsync($"/api/Owner/{OwnerEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_OwnersDoNotExist_ReturnsEmptyResponseWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync("/api/Owner");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(await response.Content.ReadAsAsync<List<OwnerViewModel>>());
        }

        [Theory]
        [ClassData(typeof(PostValidOwnersTestData))]
        public async Task Add_ValidOwner_ReturnsOwnerWithOKStatusCode(PostOwnerViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            var content = SerializeObjectToHttpContent(model);

            var postResponse = await _httpClient.PostAsync("/api/Owner", content);

            var getResponse = await _httpClient.GetAsync("/api/Owner");
            var actual = await getResponse.Content.ReadAsAsync<List<OwnerViewModel>>();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            Assert.NotEmpty(actual);
            Assert.Equal(model.FullName, actual.FirstOrDefault().FullName);
        }

        [Theory]
        [ClassData(typeof(PostOwnersWithInvalidFullNamesTestData))]
        public async Task Add_OwnerWithInvalidName_ValidationFailsWithBadRequestStatusCode(PostOwnerViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PostAsync("/api/Owner", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateOwnersWithInvalidFullNamesTestData))]
        public async Task Update_OwnerWithInvalidName_ValidationFailsWithBadRequestStatusCode(UpdateOwnerViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddAsync(ValidOwnerEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PutAsync($"/api/Owner/{ValidOwnerEntity.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidOwnersTestData))]
        public async Task Update_ValidOwnerViewModel_ReturnsOwnerWithOKStatusCode(UpdateOwnerViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddAsync(ValidOwnerEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var putResponse = await _httpClient.PutAsync($"/api/Owner/{ValidOwnerEntity.Id}", content);

            var getResponse = await _httpClient.GetAsync($"/api/Owner/{ValidOwnerEntity.Id}");
            var actual = await getResponse.Content.ReadAsAsync<OwnerViewModel>();

            Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(model.FullName, actual.FullName);
        }
    }
}
