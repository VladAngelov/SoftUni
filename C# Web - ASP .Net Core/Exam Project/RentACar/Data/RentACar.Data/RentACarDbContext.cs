namespace RentACar.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class RentACarDbContext : IdentityDbContext<RentACarUser, IdentityRole, string>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public RentACarDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}