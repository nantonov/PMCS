using AutoMapper;
using PMCS.API.ViewModels.Owner;
using PMCS.API.ViewModels.Pet;
using PMCS.DAL.Entities;
using PMCS.DLL.Models;

namespace PMCS.API.Mapper.Profiles
{
    public class ModelViewModelProfile : Profile
    {
        public ModelViewModelProfile()
        {
            CreateMap<OwnerModel, PostOwnerViewModel>().ReverseMap();
            CreateMap<OwnerModel, UpdateOwnerViewModel>().ReverseMap();

            CreateMap<PetEntity, PostPetViewModel>().ReverseMap();
            CreateMap<PetEntity, UpdatePetViewModel>().ReverseMap();
        }
    }
}
