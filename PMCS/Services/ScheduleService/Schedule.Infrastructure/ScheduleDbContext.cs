using MediatR;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Entities;
using Schedule.Infrastructure.EntityConfigurations;

namespace Schedule.Infrastructure
{
    public class ScheduleDbContext : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }

        private readonly IMediator _mediator;

        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options, IMediator mediator) : base(options)
        {
            if (Database.IsRelational()) Database.Migrate();

            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReminderEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
