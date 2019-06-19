namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCustomerEntity(modelBuilder);

            ConfigureProductEntity(modelBuilder);

            ConfigureStoreEntity(modelBuilder);

            ConfigureSaleEntity(modelBuilder);
        }

        private void ConfigureSaleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            //modelBuilder
            //    .Entity<Sale>()
            //    .Property(s => s.Data)
            //    .IsRequired();

            //modelBuilder
            //    .Entity<Sale>()
            //    .HasOne(s => s.Customer)
            //    .WithMany(s => s.Sales);

            //modelBuilder
            //    .Entity<Sale>()
            //    .HasOne(s => s.Product)
            //    .WithMany(s => s.Sales);

            //modelBuilder
            //    .Entity<Sale>()
            //    .HasOne(s => s.Store)
            //    .WithMany(s => s.Sales);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Data)
                .HasDefaultValueSql("GETDATE()");
        }

        private void ConfigureStoreEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250);
        }

        private void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(c => c.Customer);
        }
    }
}