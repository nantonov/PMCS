using PMCS.API.Tests.ViewModels.Meal;
using PMCS.API.ViewModels.Meal;
using static PMCS.API.Tests.Entities.MealEntities;

namespace PMCS.API.Tests
{
    [Collection("Sequential")]
    public class MealControllerTests : APIIntegrationTestsBase
    {
        [Fact]
        public async Task GetById_MealWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.GetAsync($"/api/Meal/{MealEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById_MealWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Meal/{MealEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_MealAndPetExist_DeletesMealAndReturnsOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Meal/{ValidMealEntity.Id}");

            var getResponse = await _httpClient.GetAsync("/api/Meal");

            var actual = await getResponse.Content.ReadAsAsync<List<MealViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task Delete_MealWithInexistentId_SetsNotFoundStatusCode()
        {
            var response = await _httpClient.DeleteAsync($"/api/Meal/{MealEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_MealWithInexistentPetId_SetsNotFoundStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync($"/api/Meal/{MealEntityWithInvalidId.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_MealsDoNotExist_ReturnsEmptyResponseWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync("/api/Meal");
            var actual = await response.Content.ReadAsAsync<List<MealViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetById_MealAndPetExist_ReturnsPetWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"/api/Meal/{ValidMealEntity.Id}");

            var expected = ValidMealEntity;
            var actual = await response.Content.ReadAsAsync<MealViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Theory]
        [ClassData(typeof(PostValidMealsTestData))]
        public async Task Add_ValidMeal_ReturnsModelWithOKStatusCode(PostMealViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var postResponse = await _httpClient.PostAsync("/api/Meal", content);

            var getResponse = await _httpClient.GetAsync($"/api/Meal/");
            var actual = await getResponse.Content.ReadAsAsync<List<MealViewModel>>();

            Assert.Equal(HttpStatusCode.OK, postResponse.StatusCode);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.FirstOrDefault(x => x.Title == model.Title));
        }

        [Theory]
        [ClassData(typeof(PostInvalidMealsTestData))]
        public async Task Add_MealWithInvalidData_ValidationFailsWithBadRequestStatusCode(PostMealViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PostAsync("/api/Meal", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateInvalidMealsTestData))]
        public async Task Update_MealWithInvalidData_ValidationFailsWithBadRequestStatusCode(UpdateMealViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var response = await _httpClient.PutAsync($"/api/Meal/{ValidMealEntity.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [ClassData(typeof(UpdateValidMealsTestData))]
        public async Task Update_ValidMealViewModel_ReturnsMealWithOKStatusCode(UpdateMealViewModel model)
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddAsync(ValidMealEntity);
            await _context.SaveChangesAsync();

            var content = SerializeObjectToHttpContent(model);

            var putResponse = await _httpClient.PutAsync($"/api/Meal/{ValidMealEntity.Id}", content);

            var getResponse = await _httpClient.GetAsync($"/api/Meal/{ValidMealEntity.Id}");
            var actual = await getResponse.Content.ReadAsAsync<MealViewModel>();

            Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);
            Assert.NotNull(actual);
            Assert.Equal(model.Title, actual.Title);
        }

        [Fact]
        public async Task GetAll_MealsExist_ReturnsMealsListWithOKStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.Pets.AddAsync(PetEntityForRelatedEntitiesTests);
            await _context.Meals.AddRangeAsync(ValidMealEntityList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/api/Meal");
            var actual = await response.Content.ReadAsAsync<List<MealViewModel>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(actual);
        }
    }
}
