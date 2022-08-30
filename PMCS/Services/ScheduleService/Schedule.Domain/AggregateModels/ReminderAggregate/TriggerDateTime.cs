using Schedule.Domain.Exceptions;
using Schedule.Domain.SeedWork;

namespace Schedule.Domain.AggregateModels.ReminderAggregate
{
    public sealed record TriggerDateTime : ValueObject
    {
        public DateTime Value { get; private init; }

        public TriggerDateTime(DateTime value)
        {
            if (value > DateTime.Now || value == null)
                throw new ScheduleDomainException("The date time can't be triggered in feature");

            Value = value;
        }
    }
}
