using AutoMapper;
using PMCS.API.ViewModels.Owner;
using PMCS.API.ViewModels.Pet;
using PMCS.DLL.Models;

namespace PMCS.API.Mapper.Profiles
{
    public class ModelViewModelProfile : Profile
    {
        public ModelViewModelProfile()
        {
            CreateMap<PostOwnerViewModel, OwnerModel>();
            CreateMap<UpdateOwnerViewModel, OwnerModel>();
            CreateMap<OwnerModel, OwnerViewModel>().ReverseMap();
            CreateMap<OwnerShortViewModel, OwnerModel>().ReverseMap();

            CreateMap<PostPetViewModel, PetModel>();
            CreateMap<UpdatePetViewModel, PetModel>();
            CreateMap<PetShortViewModel, PetModel>().ReverseMap();
            CreateMap<PetViewModel, PetModel>().ReverseMap();
        }
    }
}
