﻿using IdentityModel.Client;
using Schedule.Application.Configuration;
using Schedule.Application.Core.Abstractions.Models;
using Schedule.Application.Core.Abstractions.Services;
using Schedule.Application.Core.Models.Notifications;
using Schedule.Application.Helpers;
using Schedule.Application.ResiliencePolicy;
using Schedule.Domain.Entities;
using Schedule.Domain.Enums;

namespace Schedule.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService _authService;

        public NotificationService(IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            ArgumentNullException.ThrowIfNull(httpClientFactory);
            ArgumentNullException.ThrowIfNull(authService);

            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        public async Task<INotification> Notify(Reminder reminder)
        {
            switch (reminder.NotificationType)
            {
                case NotificationType.Email:
                    {
                        var request = new EmailNotificationRequest(reminder.UserEmail, reminder.NotificationMessage);

                        var notification = await NotifyByEmail(request);

                        return notification;
                    }
                case NotificationType.PersonalAccount:
                    {
                        var request = new PersonalAccountNotificationRequest(reminder.UserId.ToString(), reminder.NotificationMessage);

                        var notification = await NotifyPersonalAccount(request);

                        return notification;
                    }
                default: throw new ArgumentNullException(nameof(reminder));
            }
        }

        private async Task<EmailNotification> NotifyByEmail(EmailNotificationRequest request)
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.NotificationClientName);

            var accessToken = await _authService.GetAccessToken(AuthConfiguration.NotificationScope);
            client.SetBearerToken(accessToken);

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await ResilientPolicy.ResilientPolicyWrapper.ExecuteAsync(() => client.PostAsync("api/notify/email", content));

            var notification = await response.Content.ReadAsAsync<EmailNotification>();

            return notification;
        }

        private async Task<PersonalAccountNotification> NotifyPersonalAccount(PersonalAccountNotificationRequest request)
        {
            var client = _httpClientFactory.CreateClient(ClientsConfiguration.NotificationClientName);

            var accessToken = await _authService.GetAccessToken(AuthConfiguration.NotificationScope);
            client.SetBearerToken(accessToken);

            var content = CommunicationServicesHelper.SerializeObjectToHttpContent(request);

            var response = await ResilientPolicy.ResilientPolicyWrapper.ExecuteAsync(() => client.PostAsync("api/notify/client", content));

            var notification = await response.Content.ReadAsAsync<PersonalAccountNotification>();

            return notification;
        }
    }
}
