using AutoMapper;
using Schedule.API.Requests;
using Schedule.API.ViewModels;
using Schedule.Application.Common.Commands;
using Schedule.Domain.Entities;

namespace Schedule.API.Mapper
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<Reminder, ReminderViewModel>();
            CreateMap<AddReminderCommand, PostReminderRequest>();
            CreateMap<UpdateReminderCommand, PutReminderRequest>();
        }
    }
}
