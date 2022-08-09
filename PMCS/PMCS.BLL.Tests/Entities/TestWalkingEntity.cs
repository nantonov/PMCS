using PMCS.DAL.Entities;

namespace PMCS.BLL.Tests.Entities
{
    public static class TestWalkingEntity
    {
        public static WalkingEntity ValidWalkingEntity = new WalkingEntity()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
        };

        public static IEnumerable<WalkingEntity> ValidWalkingEntityList = new List<WalkingEntity>()
        {
            new WalkingEntity()
            {
                Id = 1,
                Title = "Test1",
                PetId = 1,
            },
            new WalkingEntity()
            {
                Id = 2,
                Title = "Test2",
                PetId = 1,
            }
        };

        public static IEnumerable<WalkingEntity> EmptyWalkingEntityList = new List<WalkingEntity>() { };
    }
}
