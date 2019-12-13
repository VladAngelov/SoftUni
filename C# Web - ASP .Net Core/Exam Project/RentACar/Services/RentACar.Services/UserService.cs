namespace RentACar.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentACar.Data;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly RentACarDbContext context;
        private readonly IRentService rentService;

        public UserService(RentACarDbContext context, 
                           IRentService rentService)
        {
            this.context = context;
            this.rentService = rentService;
        }

        public async Task<UserServiceModel> GetByUserNameAsync(string userName)
        {
            var user = await this.context
                .Users
                .To<UserServiceModel>()
                .FirstAsync(u => u.UserName == userName);

            return user;
        }

        public async Task<List<RentViewModel>> GetMyRentAsync(string userName)
        {
            var rent = this.rentService.
                GetMyRentAsync(userName);

            return await rent;
        }
    }
}