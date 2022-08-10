using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Owner;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests
{
    public class PetRepositoryTests : DALIntegrationTestsBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;

        public PetRepositoryTests()
        {
            _petRepository = new PetRepository(_context);
            _ownerRepository = new OwnerRepository(_context);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsPetEntity()
        {
            var entity = ValidPetEntity;
            var owner = OwnerEntityForPetGetByIdTest;

            await _ownerRepository.Insert(owner, default);

            await _petRepository.Insert(entity, default);

            var actual = await _petRepository.GetById(ValidPetEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(ValidOwnerEntity.Id, actual.Id);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_ValidEntity_UpdatesEntityInDataBase()
        {
            var entity = PetEntityToUpdate;
            var owner = OwnerEntityToUpdate;

            await _ownerRepository.Insert(owner, default);
            await _petRepository.Insert(entity, default);

            entity.Name = UpdatedPetEntity.Name;
            await _petRepository.Update(entity, default);

            var actual = await _petRepository.GetById(entity.Id, default);

            Assert.Equal(entity.Name, actual.Name);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesDoNotExist_ReturnsEmptyList()
        {
            var actual = await _petRepository.Get(default);

            Assert.Empty(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_EntitiesExist_ReturnsPetEntityList()
        {
            var entities = new List<PetEntity>(ValidPetEntityList);
            var owner = ValidOwnerEntity;

            await _ownerRepository.Insert(owner, default);
            await _petRepository.InsertRange(entities, default);

            var expected = ValidPetEntityList;
            var actual = await _petRepository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _petRepository.GetById(PetEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _ownerRepository.Insert(ValidOwnerEntity, default);
            await _petRepository.Insert(PetEntityToInsert, default);

            var actual = await _petRepository.GetById(PetEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
