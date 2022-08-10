using System.Collections;

namespace PMCS.API.Tests.ViewModels
{
    public class PostValidOwnersTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new PostOwnerViewModel() { FullName = "Name Surname" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "O’Mally-Brient von M’ar III" } };
            yield return new object[] { new PostOwnerViewModel() { FullName = "Valid Name" } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
