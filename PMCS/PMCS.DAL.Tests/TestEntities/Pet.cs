﻿using PMCS.DAL.Entities;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Pet
    {
        public static PetEntity ValidPetEntity = new PetEntity()
        {
            Id = 1,
            Name = "Test",
            OwnerId = 1
        };

        public static PetEntity PetEntityWithInexistentId = new PetEntity()
        {
            Id = 1000,
            Name = "Test",
            OwnerId = 1
        };

        public static PetEntity PetEntityToInsert = new PetEntity()
        {
            Id = 4,
            Name = "Inserted",
            OwnerId = 1
        };

        public static IEnumerable<PetEntity> ValidPetEntityList = new List<PetEntity>()
        {
            new PetEntity()
            {
                Id = 1,
                Name = "First Entity",
                OwnerId = 1
            },
            new PetEntity()
            {
                Id = 2,
                Name = "Second Entity",
                OwnerId = 1
            },
            new PetEntity()
            {
                Id = 3,
                Name = "Third Entity",
                OwnerId = 1
            }
        };
    }
}