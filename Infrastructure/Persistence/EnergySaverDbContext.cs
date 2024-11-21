
using EnergySaverAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnergySaverAPI.Infrastructure.Persistence
{
    public class EnergySaverDbContext : DbContext
    {
        public EnergySaverDbContext(DbContextOptions<EnergySaverDbContext> options) : base(options) { }

        public DbSet<Poste> Postes { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<ConsumoHistorico> ConsumoHistoricos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and table names
            modelBuilder.Entity<Poste>().ToTable("Postes");
            modelBuilder.Entity<Sensor>().ToTable("Sensores");
            modelBuilder.Entity<ConsumoHistorico>().ToTable("ConsumoHistoricos");

            // Example configurations (adjust as needed)
            modelBuilder.Entity<Poste>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Sensor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<ConsumoHistorico>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ConsumoHistorico>()
                .HasOne<Poste>()
                .WithMany()
                .HasForeignKey(c => c.PosteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
