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
            Car car = AutoMapper.Mapper.Map<Car>(carServiceModel);

            this.context.Cars.Add(car);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public CarServiceModel GetById(int id)
        {
            return this.context.Cars
                .To<CarServiceModel>()
                .SingleOrDefault(car => car.Id == id);
        }

        IQueryable<CarServiceModel> ICarService.GetAllCars()
        {
            return this.context.Cars.To<CarServiceModel>();
        }
    }
}