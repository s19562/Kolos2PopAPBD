using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KolPops19562.Models
{
    public partial class s19562Context : DbContext
    {
        public s19562Context()
        {
        }

        public s19562Context(DbContextOptions<s19562Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BreedType> BreedType { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }
        public virtual DbSet<VolunteerPet> VolunteerPet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreedType>(entity =>
            {
                entity.HasKey(e => e.IdBreedType)
                    .HasName("BreedType_pk");

                entity.Property(e => e.IdBreedType).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("Pet_pk");

                entity.Property(e => e.IdPet).ValueGeneratedNever();

                entity.Property(e => e.ApprcimateDateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.BreedTypeIdBreedType).HasColumnName("BreedType_IdBreedType");

                entity.Property(e => e.DateAdopted).HasColumnType("datetime");

                entity.Property(e => e.DateRegistered).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.BreedTypeIdBreedTypeNavigation)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.BreedTypeIdBreedType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_BreedType");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("Volunteer_pk");

                entity.Property(e => e.IdVolunteer).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdSpervisorNavigation)
                    .WithMany(p => p.InverseIdSpervisorNavigation)
                    .HasForeignKey(d => d.IdSpervisor)
                    .HasConstraintName("Volunteer_Volunteer");
            });

            modelBuilder.Entity<VolunteerPet>(entity =>
            {
                entity.HasKey(e => new { e.PetIdPet, e.VolunteerIdVolunteer })
                    .HasName("Volunteer_Pet_pk");

                entity.ToTable("Volunteer_Pet");

                entity.Property(e => e.PetIdPet).HasColumnName("Pet_IdPet");

                entity.Property(e => e.VolunteerIdVolunteer).HasColumnName("Volunteer_IdVolunteer");

                entity.Property(e => e.DataAccepted).HasColumnType("datetime");

                entity.HasOne(d => d.PetIdPetNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.PetIdPet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Pet");

                entity.HasOne(d => d.VolunteerIdVolunteerNavigation)
                    .WithMany(p => p.VolunteerPet)
                    .HasForeignKey(d => d.VolunteerIdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volunteer_Pet_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
