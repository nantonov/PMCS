using PMCS.DAL.Entities;

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
            Id = 2,
            FullName = "Test Owner"
        };

        public static OwnerEntity OwnerEntityToUpdate = new OwnerEntity()
        {
            Id = 1,
            FullName = "Updated Owner"
        };

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

        public static IEnumerable<OwnerEntity> ValidOwnerEntityListWithDeletedEntity = new List<OwnerEntity>()
        {
            new OwnerEntity()
            {
                Id = 1,
                FullName = "First Entity"
            },
            new OwnerEntity()
            {
                Id = 3,
                FullName = "Third Entity"
            }
        };

        public static IEnumerable<OwnerEntity> EmptyOwnerEntityList = new List<OwnerEntity>();
    }
}
