namespace RentACarWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Web.ViewModels.Rent;

    public class RentController : Controller
    {
        private IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        [HttpGet("MyRents")]
        public async Task<IActionResult> MyRents()
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