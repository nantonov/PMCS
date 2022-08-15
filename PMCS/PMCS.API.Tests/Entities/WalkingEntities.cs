using PMCS.DAL.Entities;

namespace PMCS.API.Tests.Entities
{
    public static class WalkingEntities
    {
        public static PetEntity PetEntityForRelatedEntitiesTests = new PetEntity()
        {
            Id = 2,
            Name = "Testful",
            Owner = new OwnerEntity() { Id = 2, FullName = "Test Test" },
            OwnerId = 2
        };

        public static WalkingEntity ValidWalkingEntity = new WalkingEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 2,
            Stared = new DateTime(2022, 1, 1, 1, 1, 1),
            Finished = new DateTime(2022, 1, 1, 4, 1, 10)
        };

        public static WalkingEntity ValidWalkingWithInvalidId = new WalkingEntity()
        {
            Id = 999,
            Title = "Test",
            PetId = 2,
            Stared = new DateTime(2022, 1, 1, 1, 1, 1),
            Finished = new DateTime(2022, 1, 1, 4, 1, 10)
        };

        public static IEnumerable<WalkingEntity> ValidWalkingEntityList = new List<WalkingEntity>()
        {
            new WalkingEntity()
            {
                Id = 4,
                Title = "Test",
                PetId = 2,
                Stared = new DateTime(2022, 1, 1, 1, 1, 1),
                Finished = new DateTime(2022, 1, 1, 4, 1, 10)
            },
            new WalkingEntity()
            {
                Id = 3,
                Title = "Test",
                PetId = 2,
                Stared = new DateTime(2022, 1, 1, 1, 1, 1),
                Finished = new DateTime(2022, 1, 1, 4, 1, 10)
            }
        };
    }
}
