using PMCS.DAL.Entities;

namespace PMCS.BLL.Tests.Entities
{
    public class TestVaccineEntity
    {
        public static VaccineEntity ValidVaccineEntity = new VaccineEntity()
        {
            Id = 1,
            PetId = 1,
            Title = "Test"
        };

        public static IEnumerable<VaccineEntity> ValidVaccineEntityList = new List<VaccineEntity>()
        {
            new VaccineEntity()
            {
                Id = 1,
                PetId = 1,
                Title = "Test1"
            },
            new VaccineEntity()
            {
                Id = 2,
                PetId = 1,
                Title = "Test2"
            }
        };

        public static IEnumerable<VaccineEntity> EmptyVaccineEntityList = new List<VaccineEntity>() { };
    }
}
