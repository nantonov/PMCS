using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Meal;


namespace PMCS.DAL.Tests
{
    public class MealRepositoryTests : DALIntegrationTestsBase
    {
        private readonly IMealRepository _mealRepository;

        public MealRepositoryTests()
        {
            _mealRepository = new MealRepository(_context);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsMealEntity()
        {
            var entity = ValidMealEntity;

            await _mealRepository.Insert(entity, default);

            var actual = await _mealRepository.GetById(ValidMealEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(ValidMealEntity.Id, actual.Id);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_ValidEntity_UpdatesEntityInDataBase()
        {
            var entity = MealEntityToUpdate;

            await _mealRepository.Insert(entity, default);

            entity.Title = UpdatedMealEntity.Title;
            await _mealRepository.Update(entity, default);

            var actual = await _mealRepository.GetById(entity.Id, default);

            Assert.Equal(entity.Title, actual.Title);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await _mealRepository.Get(default);

            Assert.Empty(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesExist_ReturnsMealEntityList()
        {
            var entities = new List<MealEntity>(ValidMealEntityList);

            await _mealRepository.InsertRange(entities, default);

            var expected = ValidMealEntityList;
            var actual = await _mealRepository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _mealRepository.GetById(MealEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _mealRepository.Insert(MealEntityToInsert, default);

            var actual = await _mealRepository.GetById(MealEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
