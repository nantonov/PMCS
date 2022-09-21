using AutoMapper;
using Moq;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Models;
using PMCS.DLL.Services;
using static PMCS.BLL.Tests.Entities.TestPetEntity;
using static PMCS.BLL.Tests.Entities.TestWalkingEntity;
using static PMCS.BLL.Tests.Models.TestPetModel;
using static PMCS.BLL.Tests.Models.TestWalkingModel;

namespace PMCS.BLL.Tests
{
    public class WalkingServiceTests
    {
        private readonly Mock<IWalkingRepository> _walkingRepositoryMock = new();
        private readonly Mock<IPetRepository> _petRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new();

        [Fact]
        public async Task GetById_ValidId_ReturnsModel()
        {
            var expectedWalking = ValidWalkingEntity;

            _walkingRepositoryMock.Setup(x => x.GetById(expectedWalking.Id, default)).ReturnsAsync(expectedWalking);
            _mapperMock.Setup(m => m.Map<WalkingModel>(expectedWalking)).Returns(ValidWalkingModel);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);

            var actualWalking = await service.GetById(expectedWalking.Id, default);

            Assert.Equal(expectedWalking.Id, actualWalking.Id);
            Assert.Equal(expectedWalking.Title, actualWalking.Title);
        }


        [Fact]
        public async Task GetById_InexistentWalkingId_ThrowsModelIsNotFoundException()
        {
            _walkingRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);

            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsValidWalkingModel()
        {
            var expectedWalking = ValidWalkingModel;

            _walkingRepositoryMock.Setup(x => x.GetById(ValidWalkingEntity.Id, default)).ReturnsAsync(ValidWalkingEntity);
            _walkingRepositoryMock.Setup(x => x.Update(ValidWalkingEntity, default)).ReturnsAsync(ValidWalkingEntity);
            _petRepositoryMock.Setup(x => x.GetById(ValidPetEntity.Id, default)).ReturnsAsync(ValidPetEntity);
            _mapperMock.Setup(m => m.Map<WalkingModel>(ValidWalkingEntity)).Returns(ValidWalkingModel);
            _mapperMock.Setup(m => m.Map<WalkingEntity>(ValidWalkingModel)).Returns(ValidWalkingEntity);
            _mapperMock.Setup(m => m.Map<PetModel>(ValidPetEntity)).Returns(ValidPetModel);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var walkingService = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, petService);

            var actualWalking = await walkingService.Update(expectedWalking, default);

            _walkingRepositoryMock.Verify(x => x.Update(ValidWalkingEntity, default));
            Assert.Equal(expectedWalking.Title, actualWalking.Title);
        }

        [Fact]
        public async Task Update_ModelWithInexistentPetId_ThrowsModelIsNotFoundException()
        {
            _petRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var petService = new PetService(_petRepositoryMock.Object, _mapperMock.Object, default, _httpClientFactoryMock.Object);
            var walkingService = new WalkingService(_walkingRepositoryMock.Object, default, petService);

            async Task Act() => await walkingService.Update(ValidWalkingModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Update_ModelWithInexistentWalkingId_ThrowsModelIsNotFoundException()
        {
            _walkingRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new WalkingService(_walkingRepositoryMock.Object, default, default);

            async Task Act() => await service.Update(ValidWalkingModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task GetAll_WalkingsExist_ReturnsWalkingModelList()
        {
            var expectedWalkings = ValidWalkingEntityList;

            _walkingRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidWalkingEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<WalkingModel>>(expectedWalkings)).Returns(ValidWalkingModelList);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);

            var actualWalkings = await service.GetAll(default);

            Assert.NotEmpty(actualWalkings);
            Assert.Equal(expectedWalkings.Count(), actualWalkings.Count());
        }

        [Fact]
        public async Task GetAll_WalkingsDoNotExist_ReturnsEmptyList()
        {
            var expectedWalkings = EmptyWalkingEntityList;

            _walkingRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyWalkingEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<WalkingModel>>(expectedWalkings)).Returns(EmptyWalkingModelList);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);

            var actualWalkings = await service.GetAll(default);

            Assert.Empty(actualWalkings);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidWalkingModel()
        {
            var expectedWalking = ValidWalkingModel;

            _walkingRepositoryMock.Setup(x => x.Insert(ValidWalkingEntity, default)).ReturnsAsync(ValidWalkingEntity);
            _mapperMock.Setup(m => m.Map<WalkingModel>(ValidWalkingEntity)).Returns(ValidWalkingModel);
            _mapperMock.Setup(m => m.Map<WalkingEntity>(ValidWalkingModel)).Returns(ValidWalkingEntity);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);

            var actualWalking = await service.Add(expectedWalking, default);

            _walkingRepositoryMock.Verify(x => x.Insert(ValidWalkingEntity, default));
            Assert.Equal(expectedWalking.Id, actualWalking.Id);
            Assert.Equal(expectedWalking.Title, actualWalking.Title);
        }

        [Fact]
        public async Task Delete_InexistentWalkingId_ThrowsModelIsNotFoundException()
        {
            _walkingRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new WalkingService(_walkingRepositoryMock.Object, default, default);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ValidId_AppropriateMethodWasCalled()
        {
            var walking = ValidWalkingEntity;

            _walkingRepositoryMock.Setup(x => x.GetById(walking.Id, default)).ReturnsAsync(walking);
            _walkingRepositoryMock.Setup(x => x.Delete(walking.Id, default));
            _mapperMock.Setup(m => m.Map<WalkingModel>(ValidWalkingEntity)).Returns(ValidWalkingModel);

            var service = new WalkingService(_walkingRepositoryMock.Object, _mapperMock.Object, default);
            await service.Delete(walking.Id, default);

            _walkingRepositoryMock.Verify(x => x.Delete(walking.Id, default));
        }
    }
}
