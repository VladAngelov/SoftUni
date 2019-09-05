namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Home.Index;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = this.carService.GetAllCars()
                .Select(car => new CarHomeViewModel()
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Picture = car.Picture,
                    PricePerDay = car.PricePerDay,
                    ManufacturedOn = car.ManufacturedOn,
                }).ToList();

            return View(cars);
        }

        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}