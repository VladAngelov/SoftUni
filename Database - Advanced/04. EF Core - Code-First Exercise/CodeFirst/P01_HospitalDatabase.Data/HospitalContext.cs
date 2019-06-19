namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlserver(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();
        }
    }
}