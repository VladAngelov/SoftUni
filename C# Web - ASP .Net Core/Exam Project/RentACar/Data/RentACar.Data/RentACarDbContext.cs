namespace RentACar.Data
{
    using Models.User;
    using Models.Car;
    using Models.Rent;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class RentACarDbContext : IdentityDbContext<RentACarUser, IdentityRole, string>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public DbSet<RentStatus> RentStatuses { get; set; }

        public DbSet<CarStatus> CarStatuses { get; set; }

        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}