using IdentityServer.Models;

namespace IdentityServer.Data.Initializaton
{
    public static class InitializationData
    {
        public static User InitialUser = new User()
        {
            UserName = "TestUser",
            Email = "test@gmail.com",
        };

    }
}
