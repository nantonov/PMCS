using PMCS.BLL.Models;

namespace PMCS.BLL.Tests.Models
{
    public static class TestOwnerModel
    {
        public static OwnerModel ValidOwnerModel = new OwnerModel()
        {
            Id = 1,
            FullName = "Test User"
        };

        public static IEnumerable<OwnerModel> ValidOwnerModelList = new List<OwnerModel>()
        {
            new OwnerModel()
            {
                Id = 1,
                FullName = "First Owner"
            },
            new OwnerModel()
            {
                Id = 2,
                FullName = "Second Owner"
            }
        };

        public static IEnumerable<OwnerModel> EmptyOwnerModelList = new List<OwnerModel>() { };
    }
}
