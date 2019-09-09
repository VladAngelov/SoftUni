namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RentController : AdminController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpGet("Rents")]
        [Route("/Administration/Rents")]
        public async Task<IActionResult> Rents()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                // List<RentViewModel> rents = await this.rentService.GetAllRents()
                //.Select(rent => new RentViewModel()
                //{
                //    Id = rent.Id,
                //    CarBrand = rent.Car.Brand,
                //    CarModel = rent.Car.Model,
                //    StartDate = rent.StartDate,
                //    EndDate = rent.EndDate,
                //    Fee = rent.Fee,
                //    CarPicture = rent.Car.Picture
                //}).ToListAsync();


                //List<RentViewModel> rents = await this.rentService.GetAllRents()
                //    //.Where(rent => rent.Status.Name == "Active")
                //    .To<RentViewModel>()
                //    .ToListAsync();

               var rents = await this.rentService
                    .GetAllRents()
                   // .Where(rent => rent.Status.Name == "Active")
                    .To<RentViewModel>()
                    .ToListAsync();

                if (rents == null)
                {

                }

                return View(rents);
            }

            return View();
        }

        [HttpPost(Name = "Delete Rent")]
        public async Task <IActionResult> DeleteRent()
        {
            return View();
        }

        [HttpPost(Name = "Edit Rent")]
        public async Task<IActionResult> EditRent()
        {
            return View();
        }
    }
}