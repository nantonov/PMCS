using PMCS.DLL.Models;

namespace PMCS.BLL.Tests.Models
{
    public static class TestVaccineModel
    {
        public static VaccineModel ValidVaccineModel = new VaccineModel()
        {
            Id = 1,
            Title = "Test",
            PetId = 1,
        };

        public static IEnumerable<VaccineModel> ValidVaccineModelList = new List<VaccineModel>()
        {
            new VaccineModel()
            {
                Id = 1,
                Title = "Test1",
                PetId = 1,
            },
            new VaccineModel()
            {
                Id = 2,
                Title = "Test2",
                PetId = 1,
            }
        };

        public static IEnumerable<VaccineModel> EmptyVaccineModelList = new List<VaccineModel>() { };
    }
}
