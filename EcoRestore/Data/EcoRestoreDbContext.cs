using EcoRestore.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoRestore.Data
{
    public class EcoRestoreDbContext : DbContext
    {
        public EcoRestoreDbContext(DbContextOptions<EcoRestoreDbContext> options)
            : base(options) { }

        public DbSet<Fauna> Faunas { get; set; }
        public DbSet<PlantingPlan> PlantingPlans { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<SoilType> SoilTypes { get; set; }
        public DbSet<TreeSpecies> TreeSpecies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Fauna
            builder.Entity<Fauna>()
                .HasMany(b => b.PlantingPlans)
                .WithMany(t => t.SuggestedFauna);

            //PlantingPlan
            builder.Entity<PlantingPlan>()
                .HasOne(p => p.Plot)
                .WithMany(pl => pl.PlantingPlans)
                .HasForeignKey(p => p.PlotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PlantingPlan>()
                .HasOne(p => p.Tree)
                .WithMany()
                .HasForeignKey(p => p.TreeSpeciesId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
