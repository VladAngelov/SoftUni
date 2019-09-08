namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Services;
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
                List<RentViewModel> rents = await this.rentService.GetAllRents()
               .Select(rent => new RentViewModel()
               {
                   Id = rent.Id,
                   CarBrand = rent.Car.Brand,
                   CarModel = rent.Car.Model,
                   StartDate = rent.StartDate,
                   EndDate = rent.EndDate,
                   Fee = rent.Fee,
                   CarPicture = rent.Car.Picture
               }).ToListAsync();

                return View(rents);
            }

            return View();
        }


        // TODO: Delete and Edit Rent
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