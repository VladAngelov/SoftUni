namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RentController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpGet("Rents")]
        public async Task<IActionResult> Rents()
        {
            List<RentViewModel> rents = await this.rentService.AllRents()
                .Where(rent => rent.Status.Name == "Active")
                .To<RentViewModel>()
                .ToListAsync();
            // TODO: fix - bug maybe

            return View(rents);
        }
    }
}