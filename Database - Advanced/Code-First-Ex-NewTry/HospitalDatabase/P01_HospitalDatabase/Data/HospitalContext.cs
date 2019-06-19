﻿namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatientEntity(modelBuilder);

            ConfigureVisitationEntity(modelBuilder);

            ConfigureDiagnoseEntity(modelBuilder);

            ConfigureMedicamentEntity(modelBuilder);

            ConfigurePatientMedicamentEntity(modelBuilder);

            ConfigureDoctorEntity(modelBuilder);
        }

        private void ConfigureDoctorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Speciality)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor);
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            // Many-to-Many

            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(pm => new { pm.MedicamentId, pm.PatientId });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescription)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient);
        }
    }
}