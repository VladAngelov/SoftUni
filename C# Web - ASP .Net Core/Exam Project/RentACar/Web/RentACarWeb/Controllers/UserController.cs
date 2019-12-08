namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Web.ViewModels.User.Details;
    using System.Threading.Tasks;

    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRentService rentService;

        public UserController(IUserService userService, 
                              IRentService rentService)
        {
            this.userService = userService;
            this.rentService = rentService;
        }

        [HttpGet(Name = "Profile")]
        public async Task<IActionResult> Profile()
        {
            UserDetailsViewModel userDetailsViewModel = (await this.userService
               .GetByUserNameAsync(User.Identity.Name))
               .To<UserDetailsViewModel>();

            return View(userDetailsViewModel);
        }

        //[HttpGet(Name = "UserRent")]
        //public async Task<IActionResult> UserRent()
        //{
        //    List<RentViewModel> rent = await this.rentService
        //        .GetMyRentAsync(User.Identity.Name);

        //    return View(rent);
        //}
    }
}