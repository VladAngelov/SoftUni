namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class RentController : AdminController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }


        //[HttpGet("Rents")]
        //[Route("/Administration/Rents")]
        //public async Task<IActionResult> Rents()
        //{
        //    List<RentViewModel> rents = await this.rentService
        //        .GetAllRents()
        //        .Where(rent => rent.Status.Name == "Active")
        //        .To<RentViewModel>()
        //        .ToListAsync();

        //    return this.View(rents);
        //}


        [HttpGet("Rents")]
        [Route("/Administration/Rents")]
        public async Task<IActionResult> Rents([FromQuery]string criteria = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<RentViewModel> rents = await this.rentService.GetAllRents(criteria)
                    .Select(rent => new RentViewModel
                    {
                        CarPicture = rent.Car.Picture,
                        CarModel = rent.Car.Model,
                        PricePerDay = rent.Car.PricePerDay,
                        StartDate = rent.StartDate,
                        EndDate = rent.EndDate,
                        Fee = rent.Fee,
                    })
                    .ToListAsync();

                this.ViewData["criteria"] = criteria;

                return this.View(rents);
            }

            return View();
        }
    }
}