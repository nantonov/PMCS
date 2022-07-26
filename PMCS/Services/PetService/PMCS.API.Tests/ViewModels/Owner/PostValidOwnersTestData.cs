﻿using System.Collections;

namespace PMCS.API.Tests.ViewModels.Owner
{
    public class PostValidOwnersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostOwnerViewModel() { FullName = "Name Surname" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Alfredo Moratti" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Valid" } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
