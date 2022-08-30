using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public class ActionToRemindType : Enumeration
    {
        public ActionToRemindType(int id, string name) : base(id, name) { }

        public static ActionToRemindType GoForWalk = new ActionToRemindType(1, nameof(GoForWalk).ToLowerInvariant());
        public static ActionToRemindType FeedPet = new ActionToRemindType(2, nameof(FeedPet).ToLowerInvariant());
        public static ActionToRemindType MakeVaccine = new ActionToRemindType(3, nameof(MakeVaccine).ToLowerInvariant());

        protected override IReadOnlyList<Enumeration> Types()
        {
            return new[] { GoForWalk, FeedPet, MakeVaccine };
        }

        protected override IReadOnlyList<int> PossibleIds()
        {
            return new[] { GoForWalk.GetId, FeedPet.GetId, MakeVaccine.GetId };
        }
    }
}
