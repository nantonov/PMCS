using AutoMapper;
using PMCS.API.ViewModels.Meal;
using PMCS.API.ViewModels.Owner;
using PMCS.API.ViewModels.Pet;
using PMCS.API.ViewModels.Vaccine;
using PMCS.API.ViewModels.Walking;
using PMCS.BLL.Models;

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

            CreateMap<PostVaccineViewModel, VaccineModel>();
            CreateMap<UpdateVaccineViewModel, VaccineModel>();
            CreateMap<VaccineModel, VaccineViewModel>().ReverseMap();
            CreateMap<VaccineShortViewModel, VaccineModel>().ReverseMap();

            CreateMap<PostMealViewModel, MealModel>();
            CreateMap<UpdateMealViewModel, MealModel>();
            CreateMap<MealModel, MealViewModel>().ReverseMap();
            CreateMap<MealShortViewModel, MealModel>().ReverseMap();

            CreateMap<PostWalkingViewModel, WalkingModel>();
            CreateMap<UpdateWalkingViewModel, WalkingModel>();
            CreateMap<WalkingModel, WalkingViewModel>().ReverseMap();
            CreateMap<WalkingShortViewModel, WalkingModel>().ReverseMap();
        }
    }
}
