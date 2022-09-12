using IdentityModel.Client;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Models;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Models.Notifications;
using Schedule.Application.Helpers;
using Schedule.Application.ResiliencePolicy;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;

namespace Schedule.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;
        private readonly IAuthService _authService;

        public NotificationService(IHttpClientFactory httpClientFactory, IIdentityService identityService, IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
            _authService = authService;
        }

        public async Task<INotification> Notify(Reminder reminder)
        {
            switch (reminder.NotificationType)
            {
                case NotificationType.Email:
                    {
                        var request = new EmailNotificationRequest(_identityService.GetUserEmail(), reminder.NotificationMessage);

                        var notification = await NotifyByEmail(request);

                        return notification;
                    }
                case NotificationType.PersonalAccount:
                    {
                        var request = new PersonalAccountNotificationRequest(_identityService.GetUserId().ToString(), reminder.NotificationMessage);

                        var notification = await NotifyPersonalAccount(request);

                        return notification;
                    }
                default: throw new NullReferenceException();
            }
        }

        private async Task<EmailNotification> NotifyByEmail(EmailNotificationRequest request)
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.NotificationClientName);

            var accessToken = await _authService.GetAccessToken(AuthConfiguration.NotificationScope);
            client.SetBearerToken(accessToken);

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await ResilientPolicy.ResilientPolicyWrapper.ExecuteAsync(() => client.PostAsync("/email", content));

            var notification = await response.Content.ReadAsAsync<EmailNotification>();

            return notification;
        }

        private async Task<PersonalAccountNotification> NotifyPersonalAccount(PersonalAccountNotificationRequest request)
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.NotificationClientName);

            var accessToken = await _authService.GetAccessToken(AuthConfiguration.NotificationScope);
            client.SetBearerToken(accessToken);

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await ResilientPolicy.ResilientPolicyWrapper.ExecuteAsync(() => client.PostAsync("/client", content));

            var notification = await response.Content.ReadAsAsync<PersonalAccountNotification>();

            return notification;
        }
    }
}
