using AutoMapper;
using Moq;
using PMCS.DAL.Entities;
using PMCS.DAL.Interfaces.Repositories;
using PMCS.DLL.Exceptions;
using PMCS.DLL.Models;
using PMCS.DLL.Services;
using static PMCS.BLL.Tests.Entities.TestOwnerEntity;
using static PMCS.BLL.Tests.Models.TestOwnerModel;

namespace PMCS.BLL.Tests
{
    public class OwnerServiceTests
    {
        private readonly Mock<IOwnerRepository> _ownerRepositoryMock = new();

        private readonly Mock<IMapper> _mapperMock = new();

        [Fact]
        public async Task GetById_ShouldReturnOwner_WhenOwnerExists()
        {
            var expectedOwner = ValidOwnerEntity;

            _ownerRepositoryMock.Setup(x => x.GetById(expectedOwner.Id, default)).ReturnsAsync(expectedOwner);
            _mapperMock.Setup(m => m.Map<OwnerModel>(expectedOwner)).Returns(ValidOwnerModel);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await _sut.GetById(expectedOwner.Id, default);

            Assert.Equal(expectedOwner.Id, actualOwner.Id);
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task GetById_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            async Task Act() => await _sut.GetById(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Get_ShouldReturnAllOwners_WhenOwnersExist()
        {
            var expectedOwners = ValidOwnerEntityList;

            _ownerRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(ValidOwnerEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<OwnerModel>>(expectedOwners)).Returns(ValidOwnerModelList);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var actualOwners = await _sut.GetAll(default);

            Assert.NotEmpty(actualOwners);
            Assert.Equal(expectedOwners.Count(), actualOwners.Count());
        }

        [Fact]
        public async Task Get_ShouldReturnEmptyList_WhenOwnersDoNotExist()
        {
            var expectedOwners = EmptyOwnerEntityList;

            _ownerRepositoryMock.Setup(x => x.Get(default)).ReturnsAsync(EmptyOwnerEntityList);
            _mapperMock.Setup(m => m.Map<IEnumerable<OwnerModel>>(expectedOwners)).Returns(EmptyOwnerModelList);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            var actualOwners = await _sut.GetAll(default);

            Assert.Empty(actualOwners);
        }

        [Fact]
        public async Task Add_ShouldAddOwner_WhenOwnerEntityIsValid()
        {
            var expectedOwner = ValidOwnerModel;

            _ownerRepositoryMock.Setup(x => x.GetById(ValidOwnerEntity.Id, default)).ReturnsAsync(ValidOwnerEntity);
            _ownerRepositoryMock.Setup(x => x.Insert(ValidOwnerEntity, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);
            _mapperMock.Setup(m => m.Map<OwnerEntity>(ValidOwnerModel)).Returns(ValidOwnerEntity);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await _sut.Add(expectedOwner, default);

            _ownerRepositoryMock.Verify(x => x.Insert(ValidOwnerEntity, default));
            Assert.Equal(expectedOwner.Id, actualOwner.Id);
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task Delete_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            async Task Act() => await _sut.Delete(It.IsAny<int>(), default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }

        [Fact]
        public async Task Delete_ShouldDeleteOwner_WhenOwnerExists()
        {
            var owner = ValidOwnerEntity;

            _ownerRepositoryMock.Setup(x => x.GetById(owner.Id, default)).ReturnsAsync(owner);
            _ownerRepositoryMock.Setup(x => x.Delete(owner.Id, default));
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);
            await _sut.Delete(owner.Id, default);

            _ownerRepositoryMock.Verify(x => x.Delete(owner.Id, default));
        }

        [Fact]
        public async Task Update_ShouldUpdateOwner_WhenOwnerExists()
        {
            var expectedOwner = ValidOwnerModel;

            _ownerRepositoryMock.Setup(x => x.GetById(ValidOwnerEntity.Id, default)).ReturnsAsync(ValidOwnerEntity);
            _ownerRepositoryMock.Setup(x => x.Update(ValidOwnerEntity, default)).ReturnsAsync(ValidOwnerEntity);
            _mapperMock.Setup(m => m.Map<OwnerModel>(ValidOwnerEntity)).Returns(ValidOwnerModel);
            _mapperMock.Setup(m => m.Map<OwnerEntity>(ValidOwnerModel)).Returns(ValidOwnerEntity);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            var actualOwner = await _sut.Update(expectedOwner, default);

            _ownerRepositoryMock.Verify(x => x.Update(ValidOwnerEntity, default));
            Assert.Equal(expectedOwner.FullName, actualOwner.FullName);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenOwnerDoesNotExist()
        {
            _ownerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>(), default)).ReturnsAsync(() => null);

            var _sut = new OwnerService(_ownerRepositoryMock.Object, _mapperMock.Object);

            async Task Act() => await _sut.Update(ValidOwnerModel, default);

            await Assert.ThrowsAsync<ModelIsNotFoundException>(Act);
        }
    }
}
