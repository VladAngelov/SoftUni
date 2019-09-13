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

    public class CarService : ICarService
    {
        private readonly RentACarDbContext _context;

        public CarService(RentACarDbContext context)
        {
            this._context = context;
        }

        private const string PriceLowestToHighestCarRentCriteria = "price-lowest-to-highest";

        private const string PriceHighestToLowestCarRentCriteria = "price-highest-to-lowest";

        private const string ManufacturedOnOldestToNewestCarRentCriteria = "date-oldest-to-newest";

        private const string ManufacturedOnNewestToOldestCarRentCriteria = "date-newest-to-oldest";


        public async Task<bool> Create(CarServiceModel carServiceModel)
        {
            CarStatus carStatusFromDb = await this._context
                .CarStatuses
                .SingleOrDefaultAsync(carStatus =>
                    carStatus.Name == carServiceModel.CarStatus.Name);

            if (carStatusFromDb == null)
            {
                throw new ArgumentNullException(nameof(carStatusFromDb));
            }

            Car car = AutoMapper.Mapper.Map<Car>(carServiceModel);

            car.CarStatus = carStatusFromDb;

            this._context.Cars.Add(car);

            int result = await this._context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<CarStatusServiceModel> GetAllStatuses()
        {
            return this._context.CarStatuses.To<CarStatusServiceModel>();
        }

        public async Task<CarServiceModel> GetById(int id)
        {
            var car = await this._context.Cars
                .To<CarServiceModel>()
                .FirstAsync(c => c.Id == id);

            return car;
        }

        private IQueryable<Car> GetAllCarsByPriceAscending()
        {
            return this._context.Cars.OrderBy(car => car.PricePerDay);
        }

        private IQueryable<Car> GetAllCarsByPriceDescending()
        {
            return this._context.Cars.OrderByDescending(car => car.PricePerDay);
        }

        private IQueryable<Car> GetAllCarsByManufacturedOnAscending()
        {
            return this._context.Cars.OrderBy(car => car.ManufacturedOn);
        }

        private IQueryable<Car> GetAllCarsByManufacturedOnDescending()
        {
            return this._context.Cars.OrderByDescending(car => car.ManufacturedOn);
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

            return this._context.Cars.To<CarServiceModel>();
        }

        public async Task EditAsync(int id, CarServiceModel carServiceModel)
        {
            Car carFromDb = await this._context.Cars.SingleOrDefaultAsync(car => car.Id == id);

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

            this._context.Cars.Update(carFromDb);

            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Car carFromDb = await this._context
                .Cars.FindAsync(id);

            if (carFromDb == null)
            {
                throw new ArgumentNullException(nameof(carFromDb));
            }

            this._context.Cars.Remove(carFromDb);

            this._context.SaveChanges();
        }
    }
}