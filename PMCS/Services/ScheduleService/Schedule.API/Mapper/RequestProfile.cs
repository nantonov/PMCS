using AutoMapper;
using Schedule.API.Requests;
using Schedule.Application.Common.Commands;

namespace Schedule.API.Mapper
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<PostReminderRequest, AddReminderCommand>();
            CreateMap<PutReminderRequest, UpdateReminderCommand>();
        }
    }
}
