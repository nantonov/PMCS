using AutoMapper;
using Moq;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Models;
using PMCS.DLL.Services;
using static PMCS.BLL.Tests.Entities.TestMealEntity;
using static PMCS.BLL.Tests.Entities.TestPetEntity;
using static PMCS.BLL.Tests.Models.TestMealModel;
using static PMCS.BLL.Tests.Models.TestPetModel;

namespace PMCS.BLL.Tests
{
    public class MealServiceTests
    {
        private readonly Mock<IMealRepository> _mealRepositoryMock = new();
        private readonly Mock<IPetRepository> _petRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new();

        [Fact]
        public async Task GetById_ValidId_ReturnsModel()
        {
            var expectedMeal = ValidMealEntity;

            _mealRepositoryMock.Setup(x => x.GetById(expectedMeal.Id, default)).ReturnsAsync(expectedMeal);
            _mapperMock.Setup(m => m.Map<MealModel>(expectedMeal)).Returns(ValidMealModel);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);

            var actualMeal = await service.GetById(expectedMeal.Id, default);

            Assert.Equal(expectedMeal.Id, actualMeal.Id);
            Assert.Equal(expectedMeal.Title, actualMeal.Title);
        }


        [Fact]
        public async Task GetById_InexistentMealId_ThrowsModelIsNotFoundException()
        {
            _mealRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);

            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsValidMealModel()
        {
            var expectedMeal = ValidMealModel;

            _mealRepositoryMock.Setup(x => x.GetById(ValidMealEntity.Id, default)).ReturnsAsync(ValidMealEntity);
            _mealRepositoryMock.Setup(x => x.Update(ValidMealEntity, default)).ReturnsAsync(ValidMealEntity);
            _petRepositoryMock.Setup(x => x.GetById(ValidPetEntity.Id, default)).ReturnsAsync(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<MealModel>(ValidMealEntity)).Returns(ValidMealModel);
            _mapperMock.Setup(m => m.Map<MealEntity>(ValidMealModel)).Returns(ValidMealEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var mealService = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, petService);

            var actualMeal = await mealService.Update(expectedMeal, default);

            _mealRepositoryMock.Verify(x => x.Update(ValidMealEntity, default));
            Assert.Equal(expectedMeal.Title, actualMeal.Title);
        }

        [Fact]
        public async Task Update_ModelWithInexistentPetId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var mealService = new MealService(_mealRepositoryMock.Object, default, petService);

            async Task Act() => await mealService.Update(ValidMealModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ModelWithInexistentMealId_ThrowsModelIsNotFoundException()
        {
            _mealRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new MealService(_mealRepositoryMock.Object, default, default);

            async Task Act() => await service.Update(ValidMealModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task GetAll_MealsExist_ReturnsMealModelList()
        {
            var expectedMeals = ValidMealEntityList;

            _mealRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidMealEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<MealModel>>(expectedMeals)).Returns(ValidMealModelList);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);

            var actualMeals = await service.GetAll(default);

            Assert.NotEmpty(actualMeals);
            Assert.Equal(expectedMeals.Count(), actualMeals.Count());
        }

        [Fact]
        public async Task GetAll_MealsDoNotExist_ReturnsEmptyList()
        {
            var expectedMeals = EmptyMealEntityList;

            _mealRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyMealEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<MealModel>>(expectedMeals)).Returns(EmptyMealModelList);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);

            var actualMeals = await service.GetAll(default);

            Assert.Empty(actualMeals);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidMealModel()
        {
            var expectedMeal = ValidMealModel;

            _mealRepositoryMock.Setup(x => x.Insert(ValidMealEntity, default)).ReturnsAsync(ValidMealEntity);
            _mapperMock.Setup(m => m.Map<MealModel>(ValidMealEntity)).Returns(ValidMealModel);
            _mapperMock.Setup(m => m.Map<MealEntity>(ValidMealModel)).Returns(ValidMealEntity);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);

            var actualMeal = await service.Add(expectedMeal, default);

            _mealRepositoryMock.Verify(x => x.Insert(ValidMealEntity, default));
            Assert.Equal(expectedMeal.Id, actualMeal.Id);
            Assert.Equal(expectedMeal.Title, actualMeal.Title);
        }

        [Fact]
        public async Task Delete_InexistentMealId_ThrowsModelIsNotFoundException()
        {
            _mealRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new MealService(_mealRepositoryMock.Object, default, default);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ValidId_AppropriateMethodWasCalled()
        {
            var meal = ValidMealEntity;

            _mealRepositoryMock.Setup(x => x.GetById(meal.Id, default)).ReturnsAsync(meal);
            _mealRepositoryMock.Setup(x => x.Delete(meal.Id, default));
            _mapperMock.Setup(m => m.Map<MealModel>(ValidMealEntity)).Returns(ValidMealModel);

            var service = new MealService(_mealRepositoryMock.Object, _mapperMock.Object, default);
            await service.Delete(meal.Id, default);

            _mealRepositoryMock.Verify(x => x.Delete(meal.Id, default));
        }
    }
}
