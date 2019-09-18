namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using RentACar.Services;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Rent;

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
            List<RentViewModel> rents = await this.rentService
                  .GetAllRentsAsync();

            return View(rents);
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