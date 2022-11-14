using AutoMapper;
using PMCS.BLL.Models;
using PMCS.DAL.Entities;

namespace PMCS.BLL.Mapper
{
    public class EntityModelProfile : Profile
    {
        public EntityModelProfile()
        {
            CreateMap<OwnerEntity, OwnerModel>().ReverseMap();

            CreateMap<PetEntity, PetModel>().ReverseMap();

            CreateMap<MealEntity, MealModel>().ReverseMap();

            CreateMap<WalkingEntity, WalkingModel>().ReverseMap();

            CreateMap<VaccineEntity, VaccineModel>().ReverseMap();
        }
    }
}
