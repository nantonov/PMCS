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
            CreateMap<OwnerModel, PostOwnerViewModel>();
            CreateMap<OwnerModel, UpdateOwnerViewModel>();

            CreateMap<PetModel, PostPetViewModel>();
            CreateMap<PetModel, UpdatePetViewModel>();
        }
    }
}
