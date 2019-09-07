namespace RentACar.Services
{
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRentService
    {
        Task<bool> CreateRent(RentServiceModel rentServiceModel);

        IQueryable<RentServiceModel> GetAllRents(string criteria = null);
    }
}