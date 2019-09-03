// TODO: Add admin 

//namespace RentACarWeb.Areas.Administration.Controllers
//{
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.AspNetCore.Mvc;
//    using RentACar.Data.Models;
//    using System.Threading.Tasks;

//    public class UserController : AdminController
//    {
//        private readonly UserManager<RentACarUser> userManager;

//        public UserController(UserManager<RentACarUser> userManager)
//        {
//            this.userManager = userManager;
//        }

//        public IActionResult Index()
//        {
//            this.userManager.CreateAsync(userBindingModel);

//            this.userManager.AddToRolesAsync("Admin");

//            return View();
//        }

//        [HttpGet(Name = "Create new admin")]
//        public async Task<IActionResult> CreateNewAdmin()
//        {
//            return this.View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateNewAdmin(CarCreateBindingModel carCreateBindingModel)
//        {
//            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(
//                   carCreateBindingModel.Picture,
//                   carCreateBindingModel.Model);

//            CarServiceModel carServiceModel = AutoMapper.Mapper
//                .Map<CarServiceModel>(carCreateBindingModel);

//            carServiceModel.Picture = pictureUrl;

//            await this.carService.Create(carServiceModel);

//            return this.Redirect("/");
//        }

//    }
//}