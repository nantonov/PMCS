using PMCS.API.ViewModels.Pet;
using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class PostValidPetsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostPetViewModel()
            {
                Name = "My Tuzik",
                BirthDate = new DateTime(2020, 10, 10),
                OwnerId = 1,
                Weight = 10.0f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Alberto Moratti",
                BirthDate = new DateTime(2022, 1, 1),
                OwnerId = 1,
                Info = "Some basic information",
                Weight = 0.87f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Turtle Sue",
                BirthDate = new DateTime(1980, 11, 18),
                OwnerId = 1,
                Info = "Very old one.",
                Weight = 15.687f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Almost empty",
                OwnerId = 1,
                BirthDate = new DateTime(2020, 11, 18),
            } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
