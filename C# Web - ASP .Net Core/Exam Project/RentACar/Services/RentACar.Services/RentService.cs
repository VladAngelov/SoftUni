namespace RentACar.Services
{
    using Data;
    using Data.Models.Rent;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using RentACar.Service.Mapping;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class RentService : IRentService
    {
        private readonly RentACarDbContext context;

        public RentService(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateRent(RentServiceModel rentServiceModel)
        {
            Rent rent = rentServiceModel.To<Rent>();

            rent.Status = await context.RentStatuses
                .SingleOrDefaultAsync(rentStatus => rentStatus.Name == "Active");

            rent.Car.CarStatus.Name = "Booked";

            rent.IssuedOn = DateTime.UtcNow;

            this.context.Rents.Add(rent);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<RentServiceModel> GetAllRents()
        {
             return this.context.Rents.To<RentServiceModel>();
        }
    }
}