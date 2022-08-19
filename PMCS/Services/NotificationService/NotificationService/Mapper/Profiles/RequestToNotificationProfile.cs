using AutoMapper;
using Notifications.API.Models.Requests;
using Notifications.BLL.Models.DTOs;

namespace Notifications.API.Mapper.Profiles
{
    public class RequestToNotificationProfile : Profile
    {
        public RequestToNotificationProfile()
        {
            CreateMap<EmailNotificationRequest, EmailNotification>();
            CreateMap<ClientNotificationRequest, ClientNotification>();
        }
    }
}
