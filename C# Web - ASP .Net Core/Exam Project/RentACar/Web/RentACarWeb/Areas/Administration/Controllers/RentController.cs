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

        //[HttpGet(Name = "Rents")]
        //[Route("/Rent/Rents")]
        //public async Task<IActionResult> Index()
        //{
        //    List<RentViewModel> rents = await this.rentService
        //       .GetAllRents()
        //       .Where(rent => rent.Status.Name == "Active"
        //        && rent.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
        //       .To<RentViewModel>()
        //       .ToListAsync();

        //    return this.View(rents);
        //}

        [HttpGet("Rents")]
        public async Task<IActionResult> Rents()
        {
            List<RentViewModel> rents = await this.rentService
                .GetAllRents()
                .Where(rent => rent.Status.Name == "Active"
                 && rent.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .To<RentViewModel>()
                .ToListAsync();

            return this.View(rents);
        }
    }
}