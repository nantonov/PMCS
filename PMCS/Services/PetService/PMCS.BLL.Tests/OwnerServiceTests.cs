using AutoMapper;
using Moq;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Models;
using PMCS.BLL.Services;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using static PMCS.BLL.Tests.Entities.TestOwnerEntity;
using static PMCS.BLL.Tests.Models.TestOwnerModel;

namespace PMCS.BLL.Tests
{
    public class OwnerServiceTests
    {
        private readonly Mock<IOwnerRepository> _ownerRepositoryMock = new();

        private readonly Mock<IMapper> _mapperMock = new();

        [Fact]
        public async Task GetById_ValidId_ReturnsModel()
        {
            var expectedOwner = ValidOwnerEntity;

            _ownerRepositoryMock.Setup(x => x.GetById(expectedOwner.Id, default)).ReturnsAsync(expectedOwner);
            _mapperMock.Setup(m => m.Map<OwnerModel>(expectedOwner)).Returns(ValidOwnerModel);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await service.GetById(expectedOwner.Id, default);

            Assert.Equal(expectedOwner.Id, actualOwner.Id);
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task GetById_InexistentOwnerId_ThrowsModelIsNotFoundException()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            async Task Act() => await service.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task GetAll_OwnersExist_ReturnsOwnerModelList()
        {
            var expectedOwners = ValidOwnerEntityList;

            _ownerRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidOwnerEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<OwnerModel>>(expectedOwners)).Returns(ValidOwnerModelList);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var actualOwners = await service.GetAll(default);

            Assert.NotEmpty(actualOwners);
            Assert.Equal(expectedOwners.Count(), actualOwners.Count());
        }

        [Fact]
        public async Task GetAll_OwnersDoNotExist_ReturnsEmptyList()
        {
            var expectedOwners = EmptyOwnerEntityList;

            _ownerRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyOwnerEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<OwnerModel>>(expectedOwners)).Returns(EmptyOwnerModelList);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var actualOwners = await service.GetAll(default);

            Assert.Empty(actualOwners);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidOwnerModel()
        {
            var expectedOwner = ValidOwnerModel;

            _ownerRepositoryMock.Setup(x => x.Insert(ValidOwnerEntity, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);
            _mapperMock.Setup(m => m.Map<OwnerEntity>(ValidOwnerModel)).Returns(ValidOwnerEntity);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await service.Add(expectedOwner, default);

            _ownerRepositoryMock.Verify(x => x.Insert(ValidOwnerEntity, default));
            Assert.Equal(expectedOwner.Id, actualOwner.Id);
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task Delete_InexistentOwnerId_ThrowsModelIsNotFoundException()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            async Task Act() => await service.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ValidId_AppropriateMethodWasCalled()
        {
            var owner = ValidOwnerEntity;

            _ownerRepositoryMock.Setup(x => x.GetById(owner.Id, default)).ReturnsAsync(owner);
            _ownerRepositoryMock.Setup(x => x.Delete(owner.Id, default));
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            await service.Delete(owner.Id, default);

            _ownerRepositoryMock.Verify(x => x.Delete(owner.Id, default));
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsValidOwnerModel()
        {
            var expectedOwner = ValidOwnerModel;

            _ownerRepositoryMock.Setup(x => x.GetById(ValidOwnerEntity.Id, default)).ReturnsAsync(ValidOwnerEntity);
            _ownerRepositoryMock.Setup(x => x.Update(ValidOwnerEntity, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);
            _mapperMock.Setup(m => m.Map<OwnerEntity>(ValidOwnerModel)).Returns(ValidOwnerEntity);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await service.Update(expectedOwner, default);

            _ownerRepositoryMock.Verify(x => x.Update(ValidOwnerEntity, default));
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task Update_OwnerModelWithInexistentId_ThrowsModelIsNotFoundException()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var service = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            async Task Act() => await service.Update(ValidOwnerModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }
    }
}
