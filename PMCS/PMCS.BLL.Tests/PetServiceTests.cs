using AutoMapper;
using Moq;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Models;
using PMCS.DLL.Services;
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

        [Fact]
        public async Task GetById_ShouldReturnPet_WhenPetExists()
        {
            var expectedPet = ValidPetEntity;

            _petRepositoryMock.Setup(x => x.GetById(expectedPet.Id, default)).ReturnsAsync(expectedPet);
            _mapperMock.Setup(m => m.Map<PetModel>(expectedPet)).Returns(ValidPetModel);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            var actualPet = await service.GetById(expectedPet.Id, default);

            Assert.Equal(expectedPet.Id, actualPet.Id);
            Assert.Equal(expectedPet.Name, actualPet.Name);
        }

        [Fact]
        public async Task GetById_ShouldThrowException_WhenPetDoesNotExist()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ShouldUpdateOwner_WhenOwnerAndPetExist()
        {
            var expectedPet = ValidPetModel;

            _petRepositoryMock.Setup(x => x.GetById(ValidPetEntity.Id, default)).ReturnsAsync(ValidPetEntity);
            _petRepositoryMock.Setup(x => x.Update(ValidPetEntity, default)).ReturnsAsync(ValidPetEntity);
            _ownerRepositoryMock.Setup(x => x.GetById(ValidOwnerEntity.Id, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);
            _mapperMock.Setup(m => m.Map<PetEntity>(ValidPetModel)).Returns(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);

            var ownerService = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, ownerService);

            var actualPet = await petService.Update(expectedPet, default);

            _petRepositoryMock.Verify(x => x.Update(ValidPetEntity, default));
            Assert.Equal(expectedPet.Name, actualPet.Name);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var ownerService = new OwnerService(_ownerRepositoryMock.Object, default);
            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, ownerService);

            async Task Act() => await petService.Update(ValidPetModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenPetDoesNotExist()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            async Task Act() => await service.Update(ValidPetModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Get_ShouldReturnAllPets_WhenPetsExist()
        {
            var expectedPets = ValidPetEntityList;

            _petRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidPetEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<PetModel>>(expectedPets)).Returns(ValidPetModelList);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            var actualPets = await service.GetAll(default);

            Assert.NotEmpty(actualPets);
            Assert.Equal(expectedPets.Count(), actualPets.Count());
        }

        [Fact]
        public async Task Get_ShouldReturnEmptyList_WhenOwnersDoNotExist()
        {
            var expectedPets = EmptyPetEntityList;

            _petRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyPetEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<PetModel>>(expectedPets)).Returns(EmptyPetModelList);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            var actualPets = await service.GetAll(default);

            Assert.Empty(actualPets);
        }

        [Fact]
        public async Task Add_ShouldAddPet_WhenPetEntityIsValid()
        {
            var expectedPet = ValidPetModel;

            _petRepositoryMock.Setup(x => x.Insert(ValidPetEntity, default)).ReturnsAsync(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);
            _mapperMock.Setup(m => m.Map<PetEntity>(ValidPetModel)).Returns(ValidPetEntity);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);

            var actualOwner = await service.Add(expectedPet, default);

            _petRepositoryMock.Verify(x => x.Insert(ValidPetEntity, default));
            Assert.Equal(expectedPet.Id, actualOwner.Id);
            Assert.Equal(expectedPet.Name, actualOwner.Name);
        }

        [Fact]
        public async Task Delete_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ShouldDeleteOwner_WhenOwnerExists()
        {
            var owner = ValidPetEntity;

            _petRepositoryMock.Setup(x => x.GetById(owner.Id, default)).ReturnsAsync(owner);
            _petRepositoryMock.Setup(x => x.Delete(owner.Id, default));
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);

            var service = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default);
            await service.Delete(owner.Id, default);

            _petRepositoryMock.Verify(x => x.Delete(owner.Id, default));
        }
    }
}
