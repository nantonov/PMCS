using AutoMapper;
using Moq;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Models;
using PMCS.BLL.Services;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using static PMCS.BLL.Tests.Entities.TestPetEntity;
using static PMCS.BLL.Tests.Entities.TestVaccineEntity;
using static PMCS.BLL.Tests.Models.TestPetModel;
using static PMCS.BLL.Tests.Models.TestVaccineModel;

namespace PMCS.BLL.Tests
{
    public class VaccineServiceTests
    {
        private readonly Mock<IVaccineRepository> _vaccineRepositoryMock = new();
        private readonly Mock<IPetRepository> _petRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new();

        [Fact]
        public async Task GetById_ValidId_ReturnsModel()
        {
            var expectedVaccine = ValidVaccineEntity;

            _vaccineRepositoryMock.Setup(x => x.GetById(expectedVaccine.Id, default)).ReturnsAsync(expectedVaccine);
            _mapperMock.Setup(m => m.Map<VaccineModel>(expectedVaccine)).Returns(ValidVaccineModel);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);

            var actualVaccine = await service.GetById(expectedVaccine.Id, default);

            Assert.Equal(expectedVaccine.Id, actualVaccine.Id);
            Assert.Equal(expectedVaccine.Title, actualVaccine.Title);
        }


        [Fact]
        public async Task GetById_InexistentVaccineId_ThrowsModelIsNotFoundException()
        {
            _vaccineRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);

            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsValidVaccineModel()
        {
            var expectedVaccine = ValidVaccineModel;

            _vaccineRepositoryMock.Setup(x => x.GetById(ValidVaccineEntity.Id, default)).ReturnsAsync(ValidVaccineEntity);
            _vaccineRepositoryMock.Setup(x => x.Update(ValidVaccineEntity, default)).ReturnsAsync(ValidVaccineEntity);
            _petRepositoryMock.Setup(x => x.GetById(ValidPetEntity.Id, default)).ReturnsAsync(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<VaccineModel>(ValidVaccineEntity)).Returns(ValidVaccineModel);
            _mapperMock.Setup(m => m.Map<VaccineEntity>(ValidVaccineModel)).Returns(ValidVaccineEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var vaccineService = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, petService);

            var actualVaccine = await vaccineService.Update(expectedVaccine, default);

            _vaccineRepositoryMock.Verify(x => x.Update(ValidVaccineEntity, default));
            Assert.Equal(expectedVaccine.Title, actualVaccine.Title);
        }

        [Fact]
        public async Task Update_ModelWithInexistentPetId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var vaccineService = new VaccineService(_vaccineRepositoryMock.Object, default, petService);

            async Task Act() => await vaccineService.Update(ValidVaccineModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ModelWithInexistentVaccineId_ThrowsModelIsNotFoundException()
        {
            _vaccineRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new VaccineService(_vaccineRepositoryMock.Object, default, default);

            async Task Act() => await service.Update(ValidVaccineModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task GetAll_VaccinesExist_ReturnsVaccineModelList()
        {
            var expectedVaccines = ValidVaccineEntityList;

            _vaccineRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidVaccineEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<VaccineModel>>(expectedVaccines)).Returns(ValidVaccineModelList);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);

            var actualVaccines = await service.GetAll(default);

            Assert.NotEmpty(actualVaccines);
            Assert.Equal(expectedVaccines.Count(), actualVaccines.Count());
        }

        [Fact]
        public async Task GetAll_VaccinesDoNotExist_ReturnsEmptyList()
        {
            var expectedVaccines = EmptyVaccineEntityList;

            _vaccineRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyVaccineEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<VaccineModel>>(expectedVaccines)).Returns(EmptyVaccineModelList);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);

            var actualVaccines = await service.GetAll(default);

            Assert.Empty(actualVaccines);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidVaccineModel()
        {
            var expectedVaccine = ValidVaccineModel;

            _vaccineRepositoryMock.Setup(x => x.Insert(ValidVaccineEntity, default)).ReturnsAsync(ValidVaccineEntity);
            _mapperMock.Setup(m => m.Map<VaccineModel>(ValidVaccineEntity)).Returns(ValidVaccineModel);
            _mapperMock.Setup(m => m.Map<VaccineEntity>(ValidVaccineModel)).Returns(ValidVaccineEntity);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);

            var actualVaccine = await service.Add(expectedVaccine, default);

            _vaccineRepositoryMock.Verify(x => x.Insert(ValidVaccineEntity, default));
            Assert.Equal(expectedVaccine.Id, actualVaccine.Id);
            Assert.Equal(expectedVaccine.Title, actualVaccine.Title);
        }

        [Fact]
        public async Task Delete_InexistentVaccineId_ThrowsModelIsNotFoundException()
        {
            _vaccineRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new VaccineService(_vaccineRepositoryMock.Object, default, default);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ValidId_AppropriateMethodWasCalled()
        {
            var vaccine = ValidVaccineEntity;

            _vaccineRepositoryMock.Setup(x => x.GetById(vaccine.Id, default)).ReturnsAsync(vaccine);
            _vaccineRepositoryMock.Setup(x => x.Delete(vaccine.Id, default));
            _mapperMock.Setup(m => m.Map<VaccineModel>(ValidVaccineEntity)).Returns(ValidVaccineModel);

            var service = new VaccineService(_vaccineRepositoryMock.Object, _mapperMock.Object, default);
            await service.Delete(vaccine.Id, default);

            _vaccineRepositoryMock.Verify(x => x.Delete(vaccine.Id, default));
        }
    }
}
