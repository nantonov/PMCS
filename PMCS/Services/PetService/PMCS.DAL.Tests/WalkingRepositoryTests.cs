using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Walking;

namespace PMCS.DAL.Tests
{
    public class WalkingRepositoryTests : DALIntegrationTestsBase
    {
        private readonly IWalkingRepository _repository;

        public WalkingRepositoryTests()
        {
            _repository = new WalkingRepository(_context);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsWalkingEntity()
        {
            var entity = ValidWalkingEntity;

            await _repository.Insert(entity, default);

            var actual = await _repository.GetById(ValidWalkingEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(ValidWalkingEntity.Id, actual.Id);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_ValidEntity_UpdatesEntityInDataBase()
        {
            var entity = WalkingEntityToUpdate;

            await _repository.Insert(entity, default);

            entity.Title = UpdatedWalkingEntity.Title;
            await _repository.Update(entity, default);

            var actual = await _repository.GetById(entity.Id, default);

            Assert.Equal(entity.Title, actual.Title);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await _repository.Get(default);

            Assert.Empty(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesExist_ReturnsWalkingEntityList()
        {
            var entities = new List<WalkingEntity>(ValidWalkingEntityList);

            await _repository.InsertRange(entities, default);

            var expected = ValidWalkingEntityList;
            var actual = await _repository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _repository.GetById(WalkingEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _repository.Insert(WalkingEntityToInsert, default);

            var actual = await _repository.GetById(WalkingEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
