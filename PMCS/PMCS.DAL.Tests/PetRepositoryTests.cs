using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Owner;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests
{
    [Collection("Our Test Collection #1")]
    public class PetRepositoryTests : DALIntegrationTestsBase
    {
        private readonly IPetRepository _repository;
        private readonly IOwnerRepository _ownerRepository;

        public PetRepositoryTests()
        {
            _repository = new PetRepository(_context);
            _ownerRepository = new OwnerRepository(_context);
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
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _repository.GetById(PetEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _ownerRepository.Insert(ValidOwnerEntity, default);
            await _repository.Insert(PetEntityToInsert, default);

            var actual = await _repository.GetById(PetEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        private async Task InsertInitialDataIntoDataBaseAsync()
        {
            var entities = new List<PetEntity>(ValidPetEntityList);
            var owner = ValidOwnerEntity;

            await _ownerRepository.Insert(owner, default);
            await _repository.InsertRange(entities, default);
        }
    }
}
