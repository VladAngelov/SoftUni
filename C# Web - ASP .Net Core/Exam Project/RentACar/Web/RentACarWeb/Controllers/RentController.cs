using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentACarWeb.Controllers
{
    using RentACar.Services;
    using RentACar.Web.BindingModels;

    public class RentController : Controller
    {
        private IRentService rentService;

        public RentController(IRentService rentService)
        {
            this.rentService = rentService;
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