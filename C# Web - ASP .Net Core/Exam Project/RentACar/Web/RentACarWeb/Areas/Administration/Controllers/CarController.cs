namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using RentACar.Data.Models;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CarController : AdminController
    {
        private readonly ICarService carService;

        private readonly ICloudinaryService cloudinaryService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateBindingModel carCreateBindingModel)
        {
            CarServiceModel carServiceModel = new CarServiceModel
            {
                Brand = carCreateBindingModel.Brand,
                Model = carCreateBindingModel.Model,
                Group = carCreateBindingModel.Group,
                ManufacturedOn = carCreateBindingModel.ManufacturedOn,
                PricePerDay = carCreateBindingModel.PricePerDay,
              //  Picture = carCreateBindingModel.Picture,
                AirConditioner = carCreateBindingModel.AirConditioner,
                Diesel = carCreateBindingModel.Diesel,
                AutomaticGearbox = carCreateBindingModel.AutomaticGearbox
            };

            //string pictureUrl = await this.cloudinaryService.UploadPictureAsync(
            //       carCreateBindingModel.Picture,
            //       carCreateBindingModel.Model);

          //  CarServiceModel carServiceModel = AutoMapper.Mapper.Map<CarServiceModel>(carCreateBindingModel);

            //carServiceModel.Picture = pictureUrl;

            await this.carService.Create(carServiceModel);

            return this.Redirect("/");
        }
    }
}