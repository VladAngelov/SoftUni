﻿namespace BillsPaymentSystem.Data
{
    using EntityConfigurations;
    using Models;
    using Microsoft.EntityFrameworkCore;
    
    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
        {
            
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
        }
    }
}