namespace RentACar.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.BindingModels;
    using Web.ViewModels.Rent;
   
    public interface IRentService
    {
        Task CreateRent(CarRentBindingModel carRentBindingModel, string userId);

        Task<List<RentViewModel>> GetMyRentAsync(string userName);

        Task<List<RentViewModel>> GetAllRentsAsync();
    }
}