using PMCS.BLL.Models;

namespace PMCS.BLL.Tests.Models
{
    public static class TestPetModel
    {
        public static PetModel ValidPetModel = new PetModel()
        {
            Id = 1,
            OwnerId = 1,
            Name = "Test"
        };

        public static IEnumerable<PetModel> ValidPetModelList = new List<PetModel>()
        {
            new PetModel()
            {
                Id = 1,
                OwnerId = 1,
                Name = "Test1"
            },
            new PetModel()
            {
                Id = 2,
                OwnerId = 1,
                Name = "Test2"
            }
        };

        public static IEnumerable<PetModel> EmptyPetModelList = new List<PetModel>() { };
    }
}
