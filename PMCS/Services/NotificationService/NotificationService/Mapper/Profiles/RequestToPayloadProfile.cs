using AutoMapper;
using Notifications.API.Models.Requests;
using Notifications.BLL.Models.Payloads;

namespace Notifications.API.Mapper.Profiles
{
    public class RequestToPayloadProfile : Profile
    {
        public RequestToPayloadProfile()
        {
            CreateMap<EmailNotificationRequest, EmailNotificationPayload>();
        }
    }
}
