namespace RentACarWeb.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Car.Delete;
    using RentACar.Web.ViewModels.Car.Status;
    using System.Collections.Generic;
    using System.Linq;
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
            List<CarStatusServiceModel> allCarStatuses = await this.carService
                               .GetAllStatuses()
                               .ToListAsync();

            this.ViewData["statuses"] = allCarStatuses
                .Select(carStatus => new CarCreateCarStatusViewModel
                {
                    Name = carStatus.Name
                })
                .ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateBindingModel carCreateBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                List<CarStatusServiceModel> allCarStatuses = await this.carService
                    .GetAllStatuses()
                    .ToListAsync();

                this.ViewData["statuses"] = allCarStatuses
                    .Select(carStatus => new CarCreateCarStatusViewModel
                    {
                        Name = carStatus.Name
                    })
                    .ToList();

                return this.View();
            }

            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(
                   carCreateBindingModel.Picture,
                   carCreateBindingModel.Model);

            CarServiceModel carServiceModel = AutoMapper.Mapper
                .Map<CarServiceModel>(carCreateBindingModel);

            carServiceModel.Picture = pictureUrl;

            await this.carService.Create(carServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            CarServiceModel carServiceModel = (await this.carService.GetById(id));

            if (carServiceModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(carServiceModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarServiceModel carServiceModel)
        {
            var car = carService.GetById(id).Result;
            carServiceModel.Picture = car.Picture;
            carServiceModel.CarStatus = car.CarStatus;
            carServiceModel.CarStatusId = car.CarStatusId;

            if (!this.ModelState.IsValid)
            {
                var allCarStatuses = await this.carService
                    .GetAllStatuses()
                    .ToListAsync();

                this.ViewData["types"] = allCarStatuses
                    .Select(productType => new CarCreateCarStatusViewModel
                {
                    Name = productType.Name
                })
                    .ToList(); 

                return this.View(carServiceModel);
            }
         
            await this.carService.EditAsync(id, carServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            CarDeleteViewModel carDeleteViewModel = (await this.carService.GetById(id))
                .To<CarDeleteViewModel>();

            if (carDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(carDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Car/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.carService.DeleteAsync(id);

            return this.Redirect("/");
        }

    }
}