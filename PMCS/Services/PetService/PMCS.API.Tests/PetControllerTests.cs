using PMCS.API.Tests.ViewModels.Pet;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Tests.Entities.OwnerEntities;
using static PMCS.API.Tests.Entities.PetEntities;

namespace PMCS.API.Tests
{
    [Collection("Sequential")]
    public class PetControllerTests : APIIntegrationTestsBase
    {
        [Theory]
        [ClassData(typeof(PostValidPetsTestData))]
        public async Task Add_ValidPet_ReturnsOwnerWithOKStatusCode(PostPetViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.AddAsync(ValidOwnerEntityForPetTests);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var postResponse = await _httpClient.PostAsync("/api/Pet", content);

            var getResponse = await _httpClient.GetAsync($"/api/Pet/");
            var actual = await getResponse.Content.ReadAsAsync<List<PetViewModel>>();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.FirstOrDefault(x => x.Name == model.Name));
            Assert.NotNull(actual.FirstOrDefault(x => x.BirthDate == model.BirthDate));
        }


        [Fact]
        public async Task GetAll_PetsExist_ReturnsOwnersListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddRangeAsync(ValidPetEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Pet");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(await response.Content.ReadAsAsync<List<PetViewModel>>());
        }

        [Fact]
        public async Task GetById_PetWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.GetAsync($"/api/Pet/{PetEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_OwnerExists_DeletesOwnerAndReturnsOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(ValidPetEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Pet/{ValidPetEntity.Id}");

            var getResponse = await _httpClient.GetAsync("/api/Pet");

            var actual = await getResponse.Content.ReadAsAsync<List<PetViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task Delete_PetWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.DeleteAsync($"/api/Pet/{PetEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_OwnersDoNotExist_ReturnsEmptyResponseWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync("/api/Pet");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(await response.Content.ReadAsAsync<List<PetViewModel>>());
        }

        [Fact]
        public async Task GetById_PetExists_ReturnsPetWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(ValidPetEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Pet/{ValidPetEntity.Id}");

            var expected = ValidPetEntity;
            var actual = await response.Content.ReadAsAsync<PetViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Theory]
        [ClassData(typeof(PostInvalidPetsTestData))]
        public async Task Add_PetWithInvalidName_ValidationFailsWithBadRequestStatusCode(PostPetViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.AddAsync(ValidOwnerEntityForPetTests);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PostAsync("/api/Pet", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidPetsTestData))]
        public async Task Update_PetWithInvalidData_ValidationFailsWithBadRequestStatusCode(UpdatePetViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddAsync(ValidOwnerEntityForPetTests);
            await _context.Pets.AddAsync(ValidPetEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PutAsync($"/api/Pet/{ValidOwnerEntity.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidPetsTestData))]
        public async Task Update_ValidPetViewModel_ReturnsOwnerWithOKStatusCode(UpdatePetViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Owners.AddAsync(ValidOwnerEntityForPetTests);
            await _context.Pets.AddAsync(ValidPetEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var putResponse = await _httpClient.PutAsync($"/api/Pet/{ValidPetEntity.Id}", content);

            var getResponse = await _httpClient.GetAsync($"/api/Pet/{ValidOwnerEntity.Id}");
            var actual = await getResponse.Content.ReadAsAsync<PetViewModel>();

            Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(model.Name, actual.Name);
        }

    }
}
