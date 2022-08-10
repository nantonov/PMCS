using PMCS.DAL.Entities;
using static PMCS.DAL.Tests.TestEntities.Owner;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Pet
    {
        public static PetEntity ValidPetEntity = new PetEntity()
        {
            Id = 1,
            Name = "Test",
            OwnerId = 1,
            Owner = OwnerEntityForPetTest
        };

        public static PetEntity PetEntityWithInexistentId = new PetEntity()
        {
            Id = 1000,
            Name = "Test",
            OwnerId = 1,
            Owner = ValidOwnerEntity
        };

        public static PetEntity PetEntityToInsert = new PetEntity()
        {
            Id = 4,
            Name = "Inserted",
            OwnerId = 1,
            Owner = OwnerEntityToInsert
        };

        public static PetEntity PetEntityToUpdate = new PetEntity() { Id = 10, Name = "Old Name", OwnerId = 10, Owner = OwnerEntityToUpdate };

        public static PetEntity UpdatedPetEntity = new PetEntity() { Id = 10, Name = "New Name", OwnerId = 10, Owner = OwnerEntityToUpdate };

        public static IEnumerable<PetEntity> ValidPetEntityList = new List<PetEntity>()
        {
            new PetEntity()
            {
                Id = 1,
                Name = "First Entity",
                OwnerId = 1,
                Owner = ValidOwnerEntity
            },
            new PetEntity()
            {
                Id = 2,
                Name = "Second Entity",
                OwnerId = 1,
                Owner = ValidOwnerEntity
            },
            new PetEntity()
            {
                Id = 3,
                Name = "Third Entity",
                OwnerId = 1,
                Owner = ValidOwnerEntity
            }
        };
    }
}
