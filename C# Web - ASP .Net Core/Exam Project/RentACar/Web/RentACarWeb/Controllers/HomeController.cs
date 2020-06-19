namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Home.Index;
    using System.Collections.Generic;
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

        public async Task<IActionResult> Index([FromQuery] string criteria = null)
        {
            List<CarHomeViewModel> cars = this.carService.GetAllCars(criteria)
                .Select(car => new CarHomeViewModel()
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Picture = car.Picture,
                    PricePerDay = car.PricePerDay,
                    ManufacturedOn = car.ManufacturedOn,
                    CarStatus = car.CarStatus.Name
                }).ToList();

            this.ViewData["criteria"] = criteria;

            return View(cars);
        }

        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> UserProfile()
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