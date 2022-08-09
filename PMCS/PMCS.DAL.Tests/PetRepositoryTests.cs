using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests
{
    public class PetRepositoryTests : IDisposable
    {
        private AppContext _context = new AppContext(new DbContextOptionsBuilder<AppContext>().
            UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
        private readonly IPetRepository _repository;

        public PetRepositoryTests()
        {
            _repository = new PetRepository(_context);
        }

        [Fact]
        public async Task Get_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await _repository.Get(default);

            Assert.Empty(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesExist_ReturnsPetEntityList()
        {
            await InsertInitialDataIntoDataBaseAsync();

            var expected = ValidPetEntityList;
            var actual = await _repository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_ValidId_ReturnsPetEntity()
        {
            await InsertInitialDataIntoDataBaseAsync();

            var expected = ValidPetEntity;
            var actual = await _repository.GetById(ValidPetEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _repository.GetById(PetEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_ValidId_RemovesEntityFromDatabase()
        {
            await InsertInitialDataIntoDataBaseAsync();

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            await _repository.Delete(PetEntityToDelete.Id, default);

            var actual = await _repository.GetById(PetEntityToDelete.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _repository.Insert(PetEntityToInsert, default);

            var actual = await _repository.GetById(PetEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        private async Task InsertInitialDataIntoDataBaseAsync()
        {
            var entities = new List<PetEntity>(ValidPetEntityList);

            await _repository.InsertRange(entities, default);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
