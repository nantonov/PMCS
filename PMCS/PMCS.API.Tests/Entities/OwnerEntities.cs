using PMCS.DAL.Entities;

namespace PMCS.API.Tests.Entities
{
    public static class OwnerEntities
    {
        public static OwnerEntity ValidOwnerEntity = new OwnerEntity()
        {
            Id = 1,
            FullName = "Test Owner"
        };

        public static OwnerEntity OwnerEntityWithInvalidId = new OwnerEntity()
        {
            Id = 999,
            FullName = "Test Owner"
        };

        public static IEnumerable<OwnerEntity> ValidOwnerEntityList = new List<OwnerEntity>()
        {
            new OwnerEntity()
            {
                Id = 1,
                FullName = "First Owner"
            },
            new OwnerEntity()
            {
                Id = 2,
                FullName = "Second Owner"
            },
            new OwnerEntity()
            {
                Id = 3,
                FullName = "Third Owner"
            }
        };
    }
}
