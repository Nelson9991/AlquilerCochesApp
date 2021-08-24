using AlquilerCochesApp.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AlquilerCochesApp.Data
{
    public partial class CarRentalDemoContext : DbContext
    {
        public CarRentalDemoContext()
        {
        }

        public CarRentalDemoContext(DbContextOptions<CarRentalDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistroAlquiler> RegistroAlquiler { get; set; }
        public virtual DbSet<TipoAuto> TipoAuto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarRentalDemo;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RegistroAlquiler>(entity =>
            {
                entity.ToTable("RegistroAlquiler");

                entity.Property(e => e.CostoAlquiler).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FechaAlquiler).HasColumnType("datetime");

                entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoAutoNavigation)
                    .WithMany(p => p.RegistrosAlquiler)
                    .HasForeignKey(d => d.IdTipoAuto)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RegistroAlquiler_IdTipoAuto");
            });

            modelBuilder.Entity<TipoAuto>(entity =>
            {
                entity.ToTable("TipoAuto");

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
