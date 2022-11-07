using AutoFixture.Xunit2;
using AutoMapper;
using BLL.Tests.AutoData;
using Moq;
using Notifications.API.Controllers;
using Notifications.API.Models.Requests;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;
using Shouldly;

namespace BLL.Tests.UnitTests
{
    public class NotificationTests
    {
        [Theory, AutoNotificationData]
        public async Task NotifyByEmail_ValidRequest_SendsEmail(
            SendEmailNotificationViewModel request,
            EmailNotification notification,
            [Frozen] Mock<IEmailService> emailServiceMock,
            [Frozen] Mock<IMapper> mapperMock,
            [Greedy] NotificationController controller)
        {
            emailServiceMock.Setup(x => x.SendNotification(notification)).Returns(Task.CompletedTask).Verifiable();
            mapperMock.Setup(m => m.Map<EmailNotification>(request)).Returns(notification);

            var result = await controller.NotifyByEmail(request);

            result.ShouldNotBeNull();
            emailServiceMock.Verify(x => x.SendNotification(notification), Times.Once);
        }

        [Theory, AutoNotificationData]
        public async Task NotifyClient_ValidRequest_SendsNotification(
            SendClientNotificationViewModel request,
            ClientNotification notification,
            [Frozen] Mock<IClientService> clientServiceMock,
            [Frozen] Mock<IMapper> mapperMock,
            [Greedy] NotificationController controller)
        {
            clientServiceMock.Setup(x => x.SendNotification(notification)).Returns(Task.CompletedTask).Verifiable();
            mapperMock.Setup(m => m.Map<ClientNotification>(request)).Returns(notification);

            var result = await controller.NotifyClient(request, default);

            result.ShouldNotBeNull();
            clientServiceMock.Verify(x => x.SendNotification(notification), Times.Once);
        }
    }
}