using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Tools;
using PMCS.DAL.Entities;

namespace PMCS.DAL
{
    public sealed class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<MealEntity> Meals { get; set; }
        public DbSet<WalkingEntity> Walkings { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<VaccineEntity> Vaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetPrimaryKeys(builder);
        }

        private void SetPrimaryKeys(ModelBuilder builder)
        {
            builder.Entity<MealEntity>().HasKey(x => x.Id);
            builder.Entity<PetEntity>().HasKey(x => x.Id);
            builder.Entity<VaccineEntity>().HasKey(x => x.Id);
            builder.Entity<OwnerEntity>().HasKey(x => x.Id);
            builder.Entity<WalkingEntity>().HasKey(x => x.Id);
        }
    }
}
