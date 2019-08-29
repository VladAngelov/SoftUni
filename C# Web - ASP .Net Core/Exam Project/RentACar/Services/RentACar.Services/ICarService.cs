namespace RentACar.Services
{
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<bool> Create(CarServiceModel carServiceModel);

        IQueryable<CarServiceModel> GetAllCars();
    }
}