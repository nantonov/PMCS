using AutoMapper;
using IdentityServer.Account;
using IdentityServer.Models;

namespace IdentityServer.Profiles
{
    public class ViewModelUser : Profile
    {
        public ViewModelUser()
        {
            CreateMap<User, RegisterViewModel>().ReverseMap();
        }
    }
}
