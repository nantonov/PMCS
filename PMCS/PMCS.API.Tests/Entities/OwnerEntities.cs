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
                FullName = "First Owner"
            },
            new OwnerEntity()
            {
                FullName = "Second Owner"
            },
            new OwnerEntity()
            {
                FullName = "Third Owner"
            }
        };
    }
}
