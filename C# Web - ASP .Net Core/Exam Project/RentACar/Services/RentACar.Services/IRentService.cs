namespace RentACar.Services
{
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRentService
    {
        Task CreateRent(CarRentBindingModel carRentBindingModel, string userId);

        Task<List<RentViewModel>> GetMyRentsAsync(string userId);

        Task<List<RentViewModel>> GetAllRentsAsync();
    }
}