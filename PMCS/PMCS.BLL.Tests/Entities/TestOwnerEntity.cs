using PMCS.DAL.Entities;

namespace PMCS.BLL.Tests.Entities
{
    public static class TestOwnerEntity
    {
        public static OwnerEntity ValidOwnerEntity = new OwnerEntity()
        {
            Id = 1,
            FullName = "Test User"
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
            }
        };

        public static IEnumerable<OwnerEntity> EmptyOwnerEntityList = new List<OwnerEntity>() { };
    }
}
