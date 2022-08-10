using PMCS.API.ViewModels.Pet;
using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class UpdateValidPetsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdatePetViewModel()
            {
                Name = "My Tuzik",
                BirthDate = new DateTime(2020, 10, 10),
                OwnerId = 1,
                Weight = 10.0f
            } };
            yield return new object[] { new UpdatePetViewModel()
            {
                Name = "Alberto Moratti",
                BirthDate = new DateTime(2022, 1, 1),
                OwnerId = 1,
                Info = "Some basic information",
                Weight = 0.87f
            } };
            yield return new object[] { new UpdatePetViewModel()
            {
                Name = "Turtle",
                BirthDate = new DateTime(1980, 11, 18),
                OwnerId = 1,
                Info = "Very old one.",
                Weight = 15.687f
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
