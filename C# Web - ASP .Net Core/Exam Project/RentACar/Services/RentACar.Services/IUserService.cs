namespace RentACar.Services
{
    using RentACar.Web.ViewModels.Rent;
    using Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserServiceModel> GetByUserNameAsync(string userName);

       // Task<RentViewModel> GetMyRentAsync(string userName);
    }
}