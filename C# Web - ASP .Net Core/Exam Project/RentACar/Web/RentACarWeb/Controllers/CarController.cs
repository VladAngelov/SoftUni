namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Car.Details;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CarController : Controller
    {
        private readonly ICarService carService;

        private readonly IRentService rentService;

        public CarController(ICarService carService, IRentService rentService)
        {
            this.carService = carService;
            this.rentService = rentService;
        }

        [HttpGet(Name = "Details")]
        public IActionResult Details(int id)
        {
            CarDetailsViewModel carDetailsViewModel = this.carService
                .GetById(id)
                .To<CarDetailsViewModel>();

            return View(carDetailsViewModel);
        }

        [HttpPost(Name = "Rent")]
        public async Task<IActionResult> Rent(CarRentBindingModel carRentBindingModel)
        {
            RentServiceModel rentServiceModel = carRentBindingModel.To<RentServiceModel>();

            rentServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.rentService.CreateRent(rentServiceModel);

            return this.Redirect("/");
        }
    }
}