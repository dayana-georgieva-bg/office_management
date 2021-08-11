using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SupernovaCore.Models
{
    public partial class Supernova_teamContext : DbContext
    {
        public Supernova_teamContext()
        {
        }

        public Supernova_teamContext(DbContextOptions<Supernova_teamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyResource> CompanyResources { get; set; }
        public virtual DbSet<EmployeesInformation> EmployeesInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=Supernova_team;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CompanyResource>(entity =>
            {
                entity.Property(e => e.Headphones)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LaptopModel).HasMaxLength(50);

                entity.Property(e => e.LaptopSN)
                    .HasMaxLength(50)
                    .HasColumnName("LaptopSN");

                entity.Property(e => e.MobilePhone).HasMaxLength(50);

                entity.Property(e => e.MonitorModel).HasMaxLength(50);

                entity.Property(e => e.MonitorSN)
                    .HasMaxLength(50)
                    .HasColumnName("MonitorSN");

                entity.Property(e => e.OtherInfo).HasMaxLength(200);
            });

            modelBuilder.Entity<EmployeesInformation>(entity =>
            {
                entity.ToTable("Employees_information");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.SecondName).HasMaxLength(50);

                entity.HasOne(d => d.CompanyResources)
                    .WithMany(p => p.EmployeesInformations)
                    .HasForeignKey(d => d.CompanyResourcesId)
                    .HasConstraintName("FK_Employees_information_CompanyResources");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
