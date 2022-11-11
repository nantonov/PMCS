using AutoMapper;
using Moq;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Models;
using PMCS.BLL.Services;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using static PMCS.BLL.Tests.Entities.TestOwnerEntity;
using static PMCS.BLL.Tests.Entities.TestPetEntity;
using static PMCS.BLL.Tests.Models.TestOwnerModel;
using static PMCS.BLL.Tests.Models.TestPetModel;

namespace PMCS.BLL.Tests
{
    public class PetServiceTests
    {
        private readonly Mock<IPetRepository> _petRepositoryMock = new();
        private readonly Mock<IOwnerRepository> _ownerRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new();

        [Fact]
        public async Task GetById_ValidId_ReturnsModel()
        {
            var expectedPet = ValidPetEntity;

            _petRepositoryMock.Setup(x => x.GetById(expectedPet.Id, default)).ReturnsAsync(expectedPet);
            _mapperMock.Setup(m => m.Map<PetModel>(expectedPet)).Returns(ValidPetModel);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);

            var actualPet = await service.GetById(expectedPet.Id, default);

            Assert.Equal(expectedPet.Id, actualPet.Id);
            Assert.Equal(expectedPet.Name, actualPet.Name);
        }

        [Fact]
        public async Task GetById_InexistentOwnerId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, default, default, _httpClientFactoryMock.Object);

            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsValidPetModel()
        {
            var expectedPet = ValidPetModel;

            _petRepositoryMock.Setup(x => x.GetById(ValidPetEntity.Id, default)).ReturnsAsync(ValidPetEntity);
            _petRepositoryMock.Setup(x => x.Update(ValidPetEntity, default)).ReturnsAsync(ValidPetEntity);
            _ownerRepositoryMock.Setup(x => x.GetById(ValidOwnerEntity.Id, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);
            _mapperMock.Setup(m => m.Map<PetEntity>(ValidPetModel)).Returns(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);

            var ownerService = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, ownerService, _httpClientFactoryMock.Object);

            var actualPet = await petService.Update(expectedPet, default);

            _petRepositoryMock.Verify(x => x.Update(ValidPetEntity, default));
            Assert.Equal(expectedPet.Name, actualPet.Name);
        }

        [Fact]
        public async Task Update_ModelWithInexistentOwnerId_ThrowsModelIsNotFoundException()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var ownerService = new OwnerService(_ownerRepositoryMock.Object, default);

            var petService = new PetService(_petRepositoryMock.Object, default, ownerService, _httpClientFactoryMock.Object);

            async Task Act() => await petService.Update(ValidPetModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ModelWithInexistentPetId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, default, default, _httpClientFactoryMock.Object);

            async Task Act() => await service.Update(ValidPetModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task GetAll_PetsExist_ReturnsPetModelList()
        {
            var expectedPets = ValidPetEntityList;

            _petRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidPetEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<PetModel>>(expectedPets)).Returns(ValidPetModelList);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);

            var actualPets = await service.GetAll(default);

            Assert.NotEmpty(actualPets);
            Assert.Equal(expectedPets.Count(), actualPets.Count());
        }

        [Fact]
        public async Task GetAll_PetsDoNotExist_ReturnsEmptyList()
        {
            var expectedPets = EmptyPetEntityList;

            _petRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyPetEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<PetModel>>(expectedPets)).Returns(EmptyPetModelList);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);

            var actualPets = await service.GetAll(default);

            Assert.Empty(actualPets);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidPetModel()
        {
            var expectedPet = ValidPetModel;

            _petRepositoryMock.Setup(x => x.Insert(ValidPetEntity, default)).ReturnsAsync(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);
            _mapperMock.Setup(m => m.Map<PetEntity>(ValidPetModel)).Returns(ValidPetEntity);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);

            var actualOwner = await service.Add(expectedPet, default);

            _petRepositoryMock.Verify(x => x.Insert(ValidPetEntity, default));
            Assert.Equal(expectedPet.Id, actualOwner.Id);
            Assert.Equal(expectedPet.Name, actualOwner.Name);
        }

        [Fact]
        public async Task Delete_InexistentPetId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, default, default, _httpClientFactoryMock.Object);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ValidId_AppropriateMethodWasCalled()
        {
            var owner = ValidPetEntity;

            _petRepositoryMock.Setup(x => x.GetById(owner.Id, default)).ReturnsAsync(owner);
            _petRepositoryMock.Setup(x => x.Delete(owner.Id, default));
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            await service.Delete(owner.Id, default);

            _petRepositoryMock.Verify(x => x.Delete(owner.Id, default));
        }
    }
}
