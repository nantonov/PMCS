using PMCS.API.Tests.ViewModels.Meal;
using PMCS.API.ViewModels.Vaccine;
using static PMCS.API.Tests.Entities.VaccineEntities;

namespace PMCS.API.Tests
{
    [Collection("Sequential")]
    public class VaccineControllerTests : APIIntegrationTestsBase
    {
        [Fact]
        public async Task GetById_VaccineWithInexistentId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync($"/api/Vaccine/{ValidVaccineWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById_VaccineWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Vaccine/{ValidVaccineWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_VaccineWithInexistentId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync($"/api/Vaccine/{ValidVaccineWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_VaccineWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Vaccine/{ValidVaccineWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_VaccinesDoNotExist_ReturnsEmptyResponseWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync("/api/Vaccine");
            var actual = await response.Content.ReadAsAsync<List<VaccineViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetById_VaccineAndPetExist_ReturnsPetWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Vaccine/{ValidVaccineEntity.Id}");

            var expected = ValidVaccineEntity;
            var actual = await response.Content.ReadAsAsync<VaccineViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Theory]
        [ClassData(typeof(PostValidVaccinesTestData))]
        public async Task Add_ValidVaccine_ReturnsVaccineWithOKStatusCode(PostVaccineViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var postResponse = await _httpClient.PostAsync("/api/Vaccine", content);

            var getResponse = await _httpClient.GetAsync($"/api/Vaccine/");
            var actual = await getResponse.Content.ReadAsAsync<List<VaccineViewModel>>();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.FirstOrDefault(x => x.Title == model.Title));
        }

        [Theory]
        [ClassData(typeof(PostInvalidVaccinesTestData))]
        public async Task Add_VaccineWithInvalidData_ValidationFailsWithBadRequestStatusCode(PostVaccineViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PostAsync("/api/Vaccine", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidVaccinesTestData))]
        public async Task Update_VaccineWithInvalidData_ValidationFailsWithBadRequestStatusCode(UpdateVaccineViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PutAsync($"/api/Vaccine/{ValidVaccineEntity.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidVaccinesTestData))]
        public async Task Update_ValidVaccineViewModel_ReturnsModelWithOKStatusCode(UpdateVaccineViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddAsync(ValidVaccineEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var putResponse = await _httpClient.PutAsync($"/api/Vaccine/{ValidVaccineEntity.Id}", content);

            var getResponse = await _httpClient.GetAsync($"/api/Vaccine/{ValidVaccineEntity.Id}");
            var actual = await getResponse.Content.ReadAsAsync<VaccineViewModel>();

            Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(model.Title, actual.Title);
        }

        [Fact]
        public async Task GetAll_VaccinesExist_ReturnsVaccinesListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Vaccines.AddRangeAsync(ValidVaccineEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Vaccine");
            var actual = await response.Content.ReadAsAsync<List<VaccineViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(actual);
        }
    }
}
