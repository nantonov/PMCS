using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Domain.Entities;

namespace Schedule.Infrastructure.EntityConfigurations
{
    public class ReminderEntityTypeConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(b => b.TriggerDateTime).IsRequired();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.PetId).IsRequired();
            builder.Property(x => x.NotificationMessage).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ActionToRemindType).IsRequired();
            builder.Property(x => x.NotificationType).IsRequired();
        }
    }
}
