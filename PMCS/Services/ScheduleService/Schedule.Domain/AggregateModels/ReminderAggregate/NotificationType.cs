using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public class NotificationType : Enumeration
    {
        public NotificationType(int id, string name) : base(id, name) { }

        public static NotificationType Email = new NotificationType(1, nameof(Email).ToLowerInvariant());
        public static NotificationType PersonalAccount = new NotificationType(2, nameof(PersonalAccount).ToLowerInvariant());

        protected override IReadOnlyList<Enumeration> Types()
        {
            return new[] { Email, PersonalAccount };
        }

        protected override IReadOnlyList<int> PossibleIds()
        {
            return new[] { Email.GetId, PersonalAccount.GetId };
        }
    }
}
