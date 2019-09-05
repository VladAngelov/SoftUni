namespace RentACar.Data
{
    using Models.User;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using RentACar.Data.Models.Car;
    using RentACar.Data.Models.Rent;

    public class RentACarDbContext : IdentityDbContext<RentACarUser, IdentityRole, string>
    {
        public DbSet<RentACarUserStatus> UserStatuses { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public DbSet<RentStatus> RentStatuses { get; set; }

        public DbSet<CarStatus> CarStatuses { get; set; }

        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}