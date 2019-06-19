namespace Cinema.Data
{
    using Models;

    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)   { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   ModelCreatingCustomer(modelBuilder);
        }

        private void ModelCreatingCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.LastName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Tickets)
                .WithOne(c => c.Customer);
        }
    }
}