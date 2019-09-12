namespace RentACarWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentACar.Services;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Rent;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

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
            string myUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<RentViewModel> rents = await this.rentService
                .GetMyRentsAsync(myUserId);

            return this.View(rents);
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