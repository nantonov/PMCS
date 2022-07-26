﻿using PMCS.DAL.Entities;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Owner
    {
        public static OwnerEntity ValidOwnerEntity = new OwnerEntity()
        {
            Id = 1,
            FullName = "Test Owner"
        };

        public static OwnerEntity OwnerEntityWithInexistentId = new OwnerEntity()
        {
            Id = 1000,
            FullName = "Test Owner"
        };

        public static OwnerEntity OwnerEntityToDelete = new OwnerEntity()
        {
            Id = 1,
            FullName = "First Entity"
        };

        public static OwnerEntity OwnerEntityToInsert = new OwnerEntity()
        {
            Id = 4,
            FullName = "Inserted Owner"
        };

        public static OwnerEntity OwnerEntityToUpdate = new OwnerEntity() { Id = 10, FullName = "Old Name" };

        public static OwnerEntity UpdatedOwnerEntity = new OwnerEntity() { Id = 10, FullName = "New Name" };

        public static OwnerEntity OwnerEntityForPetTest = new OwnerEntity() { Id = 1, FullName = "For Pet" };

        public static IEnumerable<OwnerEntity> ValidOwnerEntityList = new List<OwnerEntity>()
        {
            new OwnerEntity()
            {
                Id = 1,
                FullName = "First Entity"
            },
            new OwnerEntity()
            {
                Id = 2,
                FullName = "Second Entity"
            },
            new OwnerEntity()
            {
                Id = 3,
                FullName = "Third Entity"
            }
        };
    }
}
