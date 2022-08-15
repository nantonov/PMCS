using PMCS.DAL.Entities;
using static PMCS.API.Tests.Entities.OwnerEntities;

namespace PMCS.API.Tests.Entities
{
    public static class PetEntities
    {
        public static PetEntity ValidPetEntity = new PetEntity()
        {
            Id = 1,
            Name = "Test Owner",
            OwnerId = 1,
            Owner = ValidOwnerEntityForPetTests
        };

        public static PetEntity PetEntityWithInvalidId = new PetEntity()
        {
            Id = 999,
            Name = "Test Owner",
            OwnerId = 1,
            Owner = ValidOwnerEntityForPetTests
        };

        public static IEnumerable<PetEntity> ValidPetEntityList = new List<PetEntity>()
        {
            new PetEntity()
            {
                Id = 2,
                Name = "First Owner",
                OwnerId = 1,
                Owner = ValidOwnerEntityForPetTests
            },
            new PetEntity()
            {
                Id = 3,
                Name = "Second Owner",
                OwnerId = 1,
                Owner = ValidOwnerEntityForPetTests
            },
            new PetEntity()
            {
                Id = 4,
                Name = "Third Owner",
                OwnerId = 1,
                Owner = ValidOwnerEntityForPetTests
            }
        };
    }
}
