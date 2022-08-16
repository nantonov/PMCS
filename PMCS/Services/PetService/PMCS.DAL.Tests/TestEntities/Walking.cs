using PMCS.DAL.Entities;
using static PMCS.DAL.Tests.TestEntities.Pet;

namespace PMCS.DAL.Tests.TestEntities
{
    public static class Walking
    {
        public static WalkingEntity ValidWalkingEntity = new WalkingEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
            Pet = PetEntityForRelatedEntitiesTests
        };

        public static WalkingEntity WalkingEntityWithInexistentId = new WalkingEntity()
        {
            Id = 1000,
            Title = "Test",
            PetId = 1
        };

        public static WalkingEntity WalkingEntityToInsert = new WalkingEntity()
        {
            Id = 4,
            Title = "Inserted",
            PetId = 1,
            Pet = PetEntityForRelatedEntitiesTests
        };

        public static WalkingEntity WalkingEntityToUpdate = new WalkingEntity() { Id = 10, Title = "Old Title", PetId = 1, Pet = PetEntityForRelatedEntitiesTests };

        public static WalkingEntity UpdatedWalkingEntity = new WalkingEntity() { Id = 10, Title = "New Title", PetId = 1, Pet = PetEntityForRelatedEntitiesTests };

        public static IEnumerable<WalkingEntity> ValidWalkingEntityList = new List<WalkingEntity>()
        {
            new WalkingEntity()
            {
                Id = 1,
                Title = "First Entity",
                PetId = 1,
                Pet = ValidPetEntity
            },
            new WalkingEntity()
            {
                Id = 2,
                Title = "Second Entity",
                PetId = 1,
                Pet = ValidPetEntity
            },
        };
    }
}
