﻿using AutoMapper;
using PMCS.DAL.Entities;
using PMCS.DLL.Models;

namespace PMCS.API.Mapper.Profiles
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