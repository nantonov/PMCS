using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Notifications.API.Models.Requests;
using static Notification.Tests.AutoData.TestDataConstants;

namespace BLL.Tests.AutoData
{
    public class AutoNotificationDataAttribute : AutoDataAttribute
    {
        public AutoNotificationDataAttribute() : base(() =>
        {
            var fixture = new Fixture();

            fixture.Customize<EmailNotificationRequest>(x => x.With(r => r.RecieverEmailAddress, TestAddress));
            fixture.Customize<ClientNotificationRequest>(x => x.With(r => r.UserId, TestUserId));

            fixture.Customize(new AutoMoqCustomization());

            return fixture;
        })

        { }
    }
}
