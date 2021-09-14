
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;


namespace WebapiMaestros.Domain
{
    public partial class StarWarsContext : DbContext
    {
      private readonly IConfiguration _configuracion;
      private readonly ILoggerFactory _loggerFactory;
      public StarWarsContext(IConfiguration configuracion, ILoggerFactory loggerFactory)
        {
         _configuracion = configuracion;
         _loggerFactory = loggerFactory;
      }

        public StarWarsContext(DbContextOptions<StarWarsContext> options, IConfiguration configuracion, ILoggerFactory loggerFactory)
            : base(options)
        {
         _configuracion = configuracion;
         _loggerFactory = loggerFactory;
      }

        public virtual DbSet<Army> Armies { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            //optionsBuilder.UseSqlServer("Server=PTF111\\SQLEXPRESS01;Database=StarWars;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(_configuracion["ConnectionStrings:Axesor"])
               .UseLoggerFactory(this._loggerFactory)
                .EnableSensitiveDataLogging();

         }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Army>(entity =>
            {
                entity.HasKey(e => e.IdArmy);

                entity.Property(e => e.IdArmy).HasColumnName("idArmy");

                entity.Property(e => e.ArmyName)
                    .HasMaxLength(50)
                    .HasColumnName("armyName");
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.HasKey(e => e.IdShip);

                entity.Property(e => e.IdShip).HasColumnName("idShip");

                entity.Property(e => e.IdArmy).HasColumnName("idArmy");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.ShipName)
                    .HasMaxLength(50)
                    .HasColumnName("shipName");

                entity.HasOne(d => d.IdArmyNavigation)
                    .WithMany(p => p.Ships)
                    .HasForeignKey(d => d.IdArmy)
                    .HasConstraintName("FK_Ships_Armies");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasKey(e => e.IdWeapon);

                entity.Property(e => e.IdWeapon).HasColumnName("idWeapon");

                entity.Property(e => e.IdShip).HasColumnName("idShip");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.WeaponName)
                    .HasMaxLength(150)
                    .HasColumnName("weaponName");

                entity.HasOne(d => d.IdShipNavigation)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.IdShip)
                    .HasConstraintName("FK_Weapons_Ships");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
