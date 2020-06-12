namespace RentACar.Services
{
    using Data;
    using Data.Models.Car;
    using Models;
    using Service.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RentACar.Data.Models.Rent;

    public class CarService : ICarService
    {
        private readonly RentACarDbContext context;

        public CarService(RentACarDbContext context)
        {
            this.context = context;
        }

        private const string PriceLowestToHighestCarRentCriteria = "price-lowest-to-highest";

        private const string PriceHighestToLowestCarRentCriteria = "price-highest-to-lowest";

        private const string ManufacturedOnOldestToNewestCarRentCriteria = "date-oldest-to-newest";

        private const string ManufacturedOnNewestToOldestCarRentCriteria = "date-newest-to-oldest";


        public async Task<bool> Create(CarServiceModel carServiceModel)
        {
            CarStatus carStatusFromDb = await this.context
                .CarStatuses
                .SingleOrDefaultAsync(carStatus =>
                    carStatus.Name == carServiceModel.CarStatus.Name);

            if (carStatusFromDb == null)
            {
                throw new ArgumentNullException(nameof(carStatusFromDb));
            }

            Car car = AutoMapper.Mapper.Map<Car>(carServiceModel);

            car.CarStatus = carStatusFromDb;

            this.context.Cars.Add(car);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<CarStatusServiceModel> GetAllStatuses()
        {
            return this.context.CarStatuses.To<CarStatusServiceModel>();
        }

        public async Task<CarServiceModel> GetById(int id)
        {
            var car = await this.context.Cars
                .To<CarServiceModel>()
                .FirstAsync(c => c.Id == id);

            return car;
        }

        private IQueryable<Car> GetAllCarsByPriceAscending()
        {
            return this.context.Cars.OrderBy(car => car.PricePerDay);
        }

        private IQueryable<Car> GetAllCarsByPriceDescending()
        {
            return this.context.Cars.OrderByDescending(car => car.PricePerDay);
        }

        private IQueryable<Car> GetAllCarsByManufacturedOnAscending()
        {
            return this.context.Cars.OrderBy(car => car.ManufacturedOn);
        }

        private IQueryable<Car> GetAllCarsByManufacturedOnDescending()
        {
            return this.context.Cars.OrderByDescending(car => car.ManufacturedOn);
        }

        public IQueryable<CarServiceModel> GetAllCars(string criteria = null)
        {
            switch (criteria)
            {
                case PriceLowestToHighestCarRentCriteria:
                    return this.GetAllCarsByPriceAscending().To<CarServiceModel>();

                case PriceHighestToLowestCarRentCriteria:
                    return this.GetAllCarsByPriceDescending().To<CarServiceModel>();

                case ManufacturedOnOldestToNewestCarRentCriteria:
                    return this.GetAllCarsByManufacturedOnAscending().To<CarServiceModel>();

                case ManufacturedOnNewestToOldestCarRentCriteria:
                    return this.GetAllCarsByManufacturedOnDescending().To<CarServiceModel>();
            }

            List<Car> rentedCars = this.context
                .Cars
                .Where(c => c.CarStatusId == 2)
                .ToList();

            List<Rent> rents = this.context
                .Rents
                .ToList();

            foreach (var rent in rents)
            {
                var notActive = rent.EndDate < DateTime.Now && rent.StatusId == 1;

                if (notActive)
                {
                    rent.StatusId = 2;
                    rent.Car.CarStatusId = 1;
                    this.context.SaveChanges();
                }
            }

            return this.context.Cars.To<CarServiceModel>();
        }

        public async Task EditAsync(int id, CarServiceModel carServiceModel)
        {
            Car carFromDb = await this.context
                .Cars
                .SingleOrDefaultAsync(car => car.Id == id);

            if (carFromDb == null)
            {
                throw new ArgumentNullException(nameof(carFromDb));
            }

            carFromDb.Brand = carServiceModel.Brand;
            carFromDb.Model = carServiceModel.Model;
            carFromDb.Picture = carServiceModel.Picture;
            carFromDb.PricePerDay = carServiceModel.PricePerDay;
            carFromDb.ManufacturedOn = carServiceModel.ManufacturedOn;
            carFromDb.AirConditioner = carServiceModel.AirConditioner;
            carFromDb.AutomaticGearbox = carServiceModel.AutomaticGearbox;
            carFromDb.Diesel = carServiceModel.Diesel;
            carFromDb.Group = carServiceModel.Group;
            carFromDb.CarStatus = carServiceModel.CarStatus;
            carFromDb.CarStatusId = carServiceModel.CarStatusId;

            this.context.Cars.Update(carFromDb);

            context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Car carFromDb = await this.context
                .Cars.FindAsync(id);

            if (carFromDb == null)
            {
                throw new ArgumentNullException(nameof(carFromDb));
            }

            this.context.Cars.Remove(carFromDb);

            this.context.SaveChanges();
        }
    }
}