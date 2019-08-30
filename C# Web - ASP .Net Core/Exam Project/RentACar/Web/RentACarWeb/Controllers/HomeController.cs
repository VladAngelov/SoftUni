namespace RentACarWeb.Controllers
{
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Home.Index;
    using System.Linq;
    using System.Data.Entity;
    using RentACar.Web.BindingModels;
    using System;

    public class HomeController : Controller
    {
        private readonly ICarService carService;


        public CarGroupBindingModel carGroup { get; set; }
        public CarEquipmentBindingModel carEquipment { get; set; }


        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            List<CarHomeViewModel> cars = await this.carService.GetAllCars()
                .Select(car => new CarHomeViewModel
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    PricePerDay = car.PricePerDay,
                    Picture = car.Picture,
                    ManufacturedOn = car.ManufacturedOn,
                    IsBooked = car.IsBooked,
                    CarGroup = carGroup,
                    AirConditioner = carEquipment,
                    AutomaticGearbox = carEquipment,
                    Disel = carEquipment
                })
                .ToListAsync();

            return View(cars);
        }

        public async Task<IActionResult> About()
        {
            return View();
        }

        //public async Task<IActionResult> AllActiveRrents()
        //{
        //    if (this.User.Identity.IsAuthenticated)
        //    {
        //        List<CarHomeViewModel> products = await this.carService.GetAllRents()
        //            .Select(product => new ProductHomeViewModel
        //            {
        //                Name = product.Name,
        //                Price = product.Price,
        //                Picture = product.Picture
        //            })
        //            .ToListAsync();

        //        return this.View(products);
        //    }

        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// video: 2:20:00