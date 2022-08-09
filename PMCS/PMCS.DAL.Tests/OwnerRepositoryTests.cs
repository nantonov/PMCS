using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Owner;

namespace PMCS.DAL.Tests
{
    public class OwnerRepositoryTests
    {
        private readonly DbContextOptions<AppContext> _options;
        private readonly AppContext _context;
        private readonly IOwnerRepository _repository;

        public OwnerRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppContext>().UseInMemoryDatabase("TestingDb").Options;
            _context = new AppContext(_options);
            _repository = new OwnerRepository(_context);
        }

        [Fact]
        public async Task Get_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await _repository.Get(default);

            Assert.Empty(actual);
        }

        [Fact]
        public async Task Get_EntitiesExist_ReturnsOwnerEntityList()
        {
            await InsertInitialDataIntoDataBaseAsync();

            var expected = ValidOwnerEntityList;
            var actual = await _repository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());
        }

        [Fact]
        public async Task Get_ValidId_ReturnsOwnerEntity()
        {
            var expected = ValidOwnerEntity;
            var actual = await _repository.GetById(ValidOwnerEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _repository.GetById(OwnerEntityWithInexistentId.Id, default);

            Assert.Null(actual);
        }

        [Fact]
        public async Task Delete_ValidId_RemovesEntityFromDatabase()
        {
            var expected = ValidOwnerEntityListWithDeletedEntity;
            var deletedEntity = await _repository.Delete(OwnerEntityToDelete.Id, default);

            var actual = await _repository.Get(default);

            Assert.Equal(expected.Count(), actual.Count());
            Assert.Equal(OwnerEntityToDelete.Id, deletedEntity.Id);
        }

        [Fact]
        public async Task Update_ValidEntity_UpdatesEntity()
        {
            var expected = OwnerEntityToUpdate;
            var actual = await _repository.Update(OwnerEntityToUpdate, default);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(OwnerEntityToUpdate.FullName, actual.FullName);
        }


        private async Task InsertInitialDataIntoDataBaseAsync()
        {
            await _repository.InsertRange(ValidOwnerEntityList, default);
        }
    }
}