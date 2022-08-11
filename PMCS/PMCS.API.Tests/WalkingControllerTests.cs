using PMCS.API.Tests.ViewModels.Meal;
using PMCS.API.ViewModels.Walking;
using static PMCS.API.Tests.Entities.WalkingEntities;

namespace PMCS.API.Tests
{
    [Collection("Sequential")]
    public class WalkingControllerTests : APIIntegrationTestsBase
    {
        [Fact]
        public async Task GetById_WalkingWithInexistentId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync($"/api/Walking/{ValidWalkingWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById_WalkingWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Walking/{ValidWalkingWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WalkingWithInexistentId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync($"/api/Walking/{ValidWalkingWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WalkingWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Walking/{ValidWalkingWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_WalkingsDoNotExist_ReturnsEmptyResponseWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync("/api/Walking");
            var actual = await response.Content.ReadAsAsync<List<WalkingViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetById_WalkingAndPetExist_ReturnsPetWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Walking/{ValidWalkingEntity.Id}");

            var expected = ValidWalkingEntity;
            var actual = await response.Content.ReadAsAsync<WalkingViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Theory]
        [ClassData(typeof(PostValidWalkingsTestData))]
        public async Task Add_ValidWalking_ReturnsWalkingWithOKStatusCode(PostWalkingViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var postResponse = await _httpClient.PostAsync("/api/Walking", content);

            var getResponse = await _httpClient.GetAsync($"/api/Walking/");
            var actual = await getResponse.Content.ReadAsAsync<List<WalkingViewModel>>();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.FirstOrDefault(x => x.Title == model.Title));
        }

        [Theory]
        [ClassData(typeof(PostInvalidWalkingsTestData))]
        public async Task Add_WalkingWithInvalidData_ValidationFailsWithBadRequestStatusCode(PostWalkingViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PostAsync("/api/Walking", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidWalkingsTestData))]
        public async Task Update_WalkingWithInvalidData_ValidationFailsWithBadRequestStatusCode(UpdateWalkingViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PutAsync($"/api/Walking/{ValidWalkingEntity.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidWalkingsTestData))]
        public async Task Update_ValidWalkingViewModel_ReturnsModelWithOKStatusCode(UpdateWalkingViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddAsync(ValidWalkingEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var putResponse = await _httpClient.PutAsync($"/api/Walking/{ValidWalkingEntity.Id}", content);

            var getResponse = await _httpClient.GetAsync($"/api/Walking/{ValidWalkingEntity.Id}");
            var actual = await getResponse.Content.ReadAsAsync<WalkingViewModel>();

            Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(model.Title, actual.Title);
        }

        [Fact]
        public async Task GetAll_WalkingsExist_ReturnsWalkingsListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Walkings.AddRangeAsync(ValidWalkingEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Walking");
            var actual = await response.Content.ReadAsAsync<List<WalkingViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(actual);
        }
    }
}
