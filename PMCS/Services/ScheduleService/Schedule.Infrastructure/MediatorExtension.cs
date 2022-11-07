using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Schedule.Domain.SeedWork;

namespace Schedule.Infrastructure;

static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ScheduleDbContext context)
    {
        var entitiesWithDomainEvents = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var withDomainEvents = entitiesWithDomainEvents.ToList();
        var domainEvents = GetDomainEvents(withDomainEvents);

        CleanDomainEvents(withDomainEvents);

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }

    private static IList<INotification> GetDomainEvents(IEnumerable<EntityEntry<Entity>> entities) => entities.
        SelectMany(x => x.Entity.DomainEvents!).ToList();

    private static void CleanDomainEvents(IEnumerable<EntityEntry<Entity>> entities) => entities.ToList()
        .ForEach(entity => entity.Entity.ClearDomainEvents());

}
