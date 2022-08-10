﻿using PMCS.API.ViewModels.Pet;
using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class PostInvalidPetsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostPetViewModel()
            {
                Name = "My Tuzik",
                BirthDate = new DateTime(1920, 10, 10),
                OwnerId = 1,
                Weight = 0.02f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Alberto Moratti",
                BirthDate = DateTime.UtcNow.AddMinutes(1),
                OwnerId = 1,
                Info = "Some basic information",
                Weight = 0.87f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Turtle Sue",
                BirthDate = new DateTime(1980, 11, 18),
                OwnerId = 1,
                Info = "",
                Weight = 15.687f
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Almost empty",
                OwnerId = 1,
            } };
            yield return new object[] { new PostPetViewModel()
            {
                Name = "Inv@lid Nam3",
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