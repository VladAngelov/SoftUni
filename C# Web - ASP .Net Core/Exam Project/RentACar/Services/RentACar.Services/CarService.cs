namespace RentACar.Services
{
    using Data;
    using Data.Models;
    using Models;
    using RentACar.Service.Mapping;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly RentACarDbContext context;

        public CarService(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(CarServiceModel carServiceModel)
        {
            Car car = new Car
            {
                Brand = carServiceModel.Brand,
                Model = carServiceModel.Model,
                Group = carServiceModel.Group,
                ManufacturedOn = carServiceModel.ManufacturedOn,
                PricePerDay = carServiceModel.PricePerDay,
                Picture = carServiceModel.Picture,
                AirConditioner = carServiceModel.AirConditioner,
                Diesel = carServiceModel.Diesel,
                AutomaticGearbox = carServiceModel.AutomaticGearbox
            };

            this.context.Cars.Add(car);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<CarServiceModel> GetAllCars()
        {
            return this.context.Cars
                .Select(car => new CarServiceModel
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    PricePerDay = car.PricePerDay,
                    Picture = car.Picture,
                    ManufacturedOn = car.ManufacturedOn,
                    AirConditioner = car.AirConditioner,
                    AutomaticGearbox = car.AutomaticGearbox,
                    Diesel = car.Diesel,
                    Group = car.Group,
                    IsBooked = car.IsBooked
                });

            // return this.context.Cars.To<CarServiceModel>();
        }
    }
}