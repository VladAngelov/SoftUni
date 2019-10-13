namespace RentACar.Services
{
    using Services.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserServiceModel> GetByUserNameAsync(string userName);
    }
}