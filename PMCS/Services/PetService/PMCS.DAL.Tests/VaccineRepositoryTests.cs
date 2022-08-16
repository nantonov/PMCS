using PMCS.DAL.Entities;
using PMCS.DAL.Repositories;
using static PMCS.DAL.Tests.TestEntities.Vaccine;

namespace PMCS.DAL.Tests
{
    public class VaccineRepositoryTests : DALIntegrationTestsBase
    {
        private readonly IVaccineRepository _repository;

        public VaccineRepositoryTests()
        {
            _repository = new VaccineRepository(_context);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsVaccineEntity()
        {
            var entity = ValidVaccineEntity;

            await _repository.Insert(entity, default);

            var actual = await _repository.GetById(ValidVaccineEntity.Id, default);

            Assert.NotNull(actual);
            Assert.Equal(ValidVaccineEntity.Id, actual.Id);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_ValidEntity_UpdatesEntityInDataBase()
        {
            var entity = VaccineEntityToUpdate;

            await _repository.Insert(entity, default);

            entity.Title = UpdatedVaccineEntity.Title;
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
        public async Task Get_EntitiesExist_ReturnsVaccineEntityList()
        {
            var entities = new List<VaccineEntity>(ValidVaccineEntityList);

            await _repository.InsertRange(entities, default);

            var expected = ValidVaccineEntityList;
            var actual = await _repository.Get(default);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count(), actual.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Get_InexistentId_ReturnsNull()
        {
            var actual = await _repository.GetById(VaccineEntityWithInexistentId.Id, default);

            Assert.Null(actual);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Insert_ValidEntity_InsertsEntityIntoDataBase()
        {
            await _repository.Insert(VaccineEntityToInsert, default);

            var actual = await _repository.GetById(VaccineEntityToInsert.Id, default);

            Assert.NotNull(actual);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
