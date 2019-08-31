namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using System.Threading.Tasks;

    public class CarController : AdminController
    {
        private readonly ICarService carService;

        private readonly ICloudinaryService cloudinaryService;

        public CarController(ICarService carService, ICloudinaryService cloudinaryService)
        {
            this.carService = carService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateBindingModel carCreateBindingModel)
        {
            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(
                   carCreateBindingModel.Picture,
                   carCreateBindingModel.Model);

            CarServiceModel carServiceModel = AutoMapper.Mapper
                .Map<CarServiceModel>(carCreateBindingModel);

            carServiceModel.Picture = pictureUrl;

            await this.carService.Create(carServiceModel);

            return this.Redirect("/");
        }
    }
}