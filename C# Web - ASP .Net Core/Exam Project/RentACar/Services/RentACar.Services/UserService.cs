namespace RentACar.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentACar.Data;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
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
            var user = await this.context.Users
                        .To<UserServiceModel>()
                        .FirstAsync(u => u.UserName == userName);

            return user;
        }
    }
}