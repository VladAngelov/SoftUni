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

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Name = "Profile")]
        public async Task<IActionResult> Profile(string userName)
        {
            UserDetailsViewModel userDetailsViewModel = (await this.userService
               .GetByUserNameAsync(userName))
               .To<UserDetailsViewModel>();

            return View(userDetailsViewModel);
        }
    }
}