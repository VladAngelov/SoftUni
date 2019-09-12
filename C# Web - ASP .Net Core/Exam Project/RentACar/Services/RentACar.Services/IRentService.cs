using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Services
{
    using Web.BindingModels;
    using Web.ViewModels.Rent;
   
    public interface IRentService
    {
        Task CreateRent(CarRentBindingModel carRentBindingModel, string userId);

        Task<List<RentViewModel>> GetMyRentsAsync(string userId);

        Task<List<RentViewModel>> GetAllRentsAsync();
    }
}