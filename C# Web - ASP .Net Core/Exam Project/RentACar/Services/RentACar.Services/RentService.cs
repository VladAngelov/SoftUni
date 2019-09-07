namespace RentACar.Services
{
    using Data;
    using Data.Models.Rent;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using RentACar.Service.Mapping;
    using RentACar.Web.ViewModels.Rent;
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

            var carStatus = this.context.CarStatuses.FirstOrDefault(status => status.Name == "Booked");

            rent.Car.CarStatus = carStatus; // TODO: FIX

            rent.IssuedOn = DateTime.UtcNow;

            this.context.Rents.Add(rent);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<RentServiceModel> GetAllRents(string criteria = null)
        {
            return this.context.Rents.To<RentServiceModel>();
        }
    }
}