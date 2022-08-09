using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Owner;

namespace PMCS.DAL.Tests
{
    public class OwnerRepositoryTests : IDisposable
    {
        private AppContext _context = new AppContext(new DbContextOptionsBuilder<AppContext>().
            UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
        private readonly IOwnerRepository _repository;

        public OwnerRepositoryTests()
        {
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
            await InsertInitialDataIntoDataBaseAsync();

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
            await InsertInitialDataIntoDataBaseAsync();

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            await _repository.Delete(OwnerEntityToDelete.Id, default);

            var actual = await _repository.GetById(OwnerEntityToDelete.Id, default);

            Assert.Null(actual);
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _repository.Insert(OwnerEntityToInsert, default);

            var actual = await _repository.GetById(OwnerEntityToInsert.Id, default);

            Assert.NotNull(actual);
        }

        private async Task InsertInitialDataIntoDataBaseAsync()
        {
            var entities = new List<OwnerEntity>(ValidOwnerEntityList);

            await _repository.InsertRange(entities, default);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}