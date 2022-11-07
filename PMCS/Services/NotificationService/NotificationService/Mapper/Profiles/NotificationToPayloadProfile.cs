using AutoMapper;
using Notifications.BLL.Models.DTOs;
using Notifications.BLL.Models.Payloads;

namespace Notifications.API.Mapper.Profiles
{
    public class NotificationToPayloadProfile : Profile
    {
        public NotificationToPayloadProfile()
        {
            CreateMap<ClientNotification, ClientNotificationPayload>();
            CreateMap<EmailNotification, EmailNotificationPayload>();
        }
    }
}
