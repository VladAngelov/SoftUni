namespace RentACar.Services
{
    using Data;
    using Data.Models.Rent;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using RentACar.Data.Models.Car;
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

            IQueryable<decimal> price = context.Cars
                .Where(c => c.Id == rent.CarId)
                .Select(s => s.PricePerDay);

            decimal fee = ((decimal)(rent.EndDate.Date - rent.StartDate.Date).Days * price.FirstOrDefault());

            rent.Fee = fee;

            rent.IssuedOn = DateTime.UtcNow;

            //var status = context.CarStatuses
            //     .SingleOrDefault(carStatus => carStatus.Name == "Booked");// TODO: FIX

            //rent.Car.CarStatus

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