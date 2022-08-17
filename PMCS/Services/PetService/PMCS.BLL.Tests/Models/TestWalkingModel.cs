using PMCS.DLL.Models;

namespace PMCS.BLL.Tests.Models
{
    public static class TestWalkingModel
    {
        public static WalkingModel ValidWalkingModel = new WalkingModel()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
        };

        public static IEnumerable<WalkingModel> ValidWalkingModelList = new List<WalkingModel>()
        {
            new WalkingModel()
            {
                Id = 1,
                Title = "Test1",
                PetId = 1
            },
            new WalkingModel()
            {
                Id = 2,
                Title = "Test2",
                PetId = 1
            }
        };

        public static IEnumerable<WalkingModel> EmptyWalkingModelList = new List<WalkingModel>() { };
    }
}
