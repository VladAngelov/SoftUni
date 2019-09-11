namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
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

        [HttpGet("Rents")]
        [Route("/Administration/Rents")]
        public async Task<IActionResult> Rents()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<RentViewModel> rents = await this.rentService
                    .GetAllRentsAsync();

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

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(CarRentBindingModel carRentBindingModel)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.rentService.CreateRent(carRentBindingModel, userId);

            return this.Redirect("/");
        }
    }
}