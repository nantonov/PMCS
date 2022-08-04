using Microsoft.EntityFrameworkCore;
using PMCS.DAL.Entities;

namespace PMCS.DAL
{
    public sealed class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<MealEntity> Meals { get; set; }
        public DbSet<WalkingEntity> Walkings { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<VaccineEntity> Vaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
