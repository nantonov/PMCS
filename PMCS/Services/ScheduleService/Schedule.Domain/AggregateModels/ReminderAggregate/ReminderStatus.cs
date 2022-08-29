using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public class ReminderStatus : Enumeration
    {
        public ReminderStatus(int id, string name) : base(id, name) { }

        public static ReminderStatus ToDo = new ReminderStatus(1, nameof(ToDo).ToLowerInvariant());
        public static ReminderStatus Done = new ReminderStatus(2, nameof(Done).ToLowerInvariant());

        public override IEnumerable<Enumeration> Types()
        {
            return new[] { ToDo, Done };
        }
    }
}
