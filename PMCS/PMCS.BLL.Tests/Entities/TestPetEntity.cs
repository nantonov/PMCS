using PMCS.DAL.Entities;

namespace PMCS.BLL.Tests.Entities
{
    public class TestPetEntity
    {
        public static PetEntity ValidPetEntity = new PetEntity()
        {
            Id = 1,
            OwnerId = 1,
            Name = "Test"
        };

        public static IEnumerable<PetEntity> ValidPetEntityList = new List<PetEntity>()
        {
            new PetEntity()
            {
                Id = 1,
                OwnerId = 1,
                Name = "Test1"
            },
            new PetEntity()
            {
                Id = 2,
                OwnerId = 1,
                Name = "Test2"
            }
        };

        public static IEnumerable<PetEntity> EmptyPetEntityList = new List<PetEntity>() { };
    }
}
