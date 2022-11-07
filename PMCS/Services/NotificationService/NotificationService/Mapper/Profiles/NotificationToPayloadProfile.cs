using AutoMapper;
using Notifications.BLL.Models.DTOs;
using Notifications.BLL.Models.Payloads;

namespace Notifications.API.Mapper.Profiles
{
    public class NotificationToPayload : Profile
    {
        public NotificationToPayload()
        {
            CreateMap<ClientNotification, ClientNotificationPayload>();
            CreateMap<EmailNotification, EmailNotificationPayload>();
        }
    }
}
