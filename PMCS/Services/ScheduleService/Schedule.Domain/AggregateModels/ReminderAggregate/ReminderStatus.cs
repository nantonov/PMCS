using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public class ReminderStatus : Enumeration
    {
        public ReminderStatus(int id, string name) : base(id, name) { }

        public static ReminderStatus ToDo = new ReminderStatus(1, nameof(ToDo).ToLowerInvariant());
        public static ReminderStatus Done = new ReminderStatus(2, nameof(Done).ToLowerInvariant());

        protected override IReadOnlyList<Enumeration> Types()
        {
            return new[] { ToDo, Done };
        }

        protected override IReadOnlyList<int> PossibleIds()
        {
            return new[] { ToDo.GetId, Done.GetId };
        }
    }
}
