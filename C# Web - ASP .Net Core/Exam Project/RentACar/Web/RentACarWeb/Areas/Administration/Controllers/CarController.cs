using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarWeb.Areas.Administration.Controllers
{
    
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Car.Delete;
    using RentACar.Web.ViewModels.Car.Status;

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
            CarEditInputModel carEditInputModel = (await this.carService.GetById(id))
                .To<CarEditInputModel>();

            if (carEditInputModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            var allCarStatuses = await this.carService.GetAllStatuses().ToListAsync();

            this.ViewData["types"] = allCarStatuses
                .Select(carStatus => new CarCreateCarStatusViewModel
            {
                Name = carStatus.Name
            })
                .ToList();

            return this.View(carEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarEditInputModel carEditInputModel)
        {
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
                    .ToList(); ;

                return this.View(carEditInputModel);
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(
                    carEditInputModel.Picture,
                    carEditInputModel.Model);

            CarServiceModel carServiceModel = AutoMapper.Mapper.Map<CarServiceModel>(carEditInputModel);

            carServiceModel.Picture = pictureUrl;
         
            await this.carService.Edit(id, carServiceModel);

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
        [Route("/Administration/Product/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.carService.Delete(id);

            return this.Redirect("/");
        }

    }
}