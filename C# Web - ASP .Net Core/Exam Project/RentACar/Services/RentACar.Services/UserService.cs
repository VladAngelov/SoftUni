namespace RentACar.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentACar.Data;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly RentACarDbContext context;

        public UserService(RentACarDbContext context)
        {
            this.context = context;
        }

        public async Task<UserServiceModel> GetByUserNameAsync(string userName)
        {
            var user = await this.context
                .Users
                .To<UserServiceModel>()
                .FirstAsync(u => u.UserName == userName);

            return user;
        }

        public async Task<RentViewModel> GetMyRentAsync(string userName)
        {
            var rents = await this.context
                .Rents
                .To<RentServiceModel>()
                .Where(rent => rent.Status
                    .Name == StaticConstantsRentService.RENT_STATUS_ACTIVE
                     && rent.User.UserName == userName)
                .To<RentViewModel>().FirstOrDefaultAsync();
                //.ToListAsync();

            return rents;
        }
    }
}