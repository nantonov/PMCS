using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Notifications.API.Models.Requests;

namespace BLL.Tests.AutoData
{
    public class AutoNotificationDataAttribute : AutoDataAttribute
    {
        private const string testAddress = "test@gmail.com";
        private const string testUserId = "1";

        public AutoNotificationDataAttribute() : base(() =>
        {
            var fixture = new Fixture();

            fixture.Customize<EmailNotificationRequest>(x => x.With(r => r.RecieverEmailAddress, testAddress));
            fixture.Customize<ClientNotificationRequest>(x => x.With(r => r.UserId, testUserId));

            fixture.Customize(new AutoMoqCustomization());

            return fixture;
        })

        { }
    }
}
