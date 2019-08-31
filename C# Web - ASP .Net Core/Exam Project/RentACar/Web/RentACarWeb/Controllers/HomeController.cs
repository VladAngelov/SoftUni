namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Home.Index;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICarService carService;
        private readonly IRentService rentService;

        public HomeController(ICarService carService, IRentService rentService)
        {
            this.carService = carService;
            this.rentService = rentService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = this.carService.GetAllCars()
                .Select(car => new CarHomeViewModel()
                {
                    Brand = car.Brand,
                    IsBooked = car.IsBooked,
                    Model = car.Model,
                    Picture = car.Picture,
                    PricePerDay = car.PricePerDay,
                    ManufacturedOn = car.ManufacturedOn
                }).ToList();

            return View(cars);
        }

        public async Task<IActionResult> AllRrents()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<RentHomeViewModel> rents = await this.rentService.GetAllRents()
                    .Select(rent => new RentHomeViewModel
                    {
                        User = rent.User.UserName,
                        CarBrand = rent.Car.Brand,
                        CarModel = rent.Car.Model,
                        Fee = rent.Fee
                    })
                    .ToListAsync();

                return this.View(rents);
            }

            return this.View();
        }

        public async Task<IActionResult> About()
        {
            return View();
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