namespace RentACarWeb.Controllers
{
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Car.Details;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(int id)
        {
            CarDetailsViewModel carDetailsViewModel = (await this.carService
                .GetById(id))
                .To<CarDetailsViewModel>();

            return View(carDetailsViewModel);
        }
    }
}