using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.BindingModels
{
    using AutoMapper;
    using Service.Mapping;
    using Services.Models;

    public class CarEditInputModel : IMapFrom<CarServiceModel>, IMapTo<CarServiceModel>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Марката е задължителна!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Моделът е задължителна!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Цената е задължителна!")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Датата на създаване е задължителна!")]
        public DateTime ManufacturedOn { get; set; }

        [Required(ErrorMessage = "Снимката е задължителна!")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "Статусът на колата е задължителна!")]
        public string CarStatus { get; set; }

        [Required(ErrorMessage = "Групата на колата е задължителна!")]
        public CarGroupBindingModel Group { get; set; }

        [Required(ErrorMessage = "Наличието на оборудването е задължителна!")]
        public CarEquipmentBindingModel AirConditioner { get; set; }

        [Required(ErrorMessage = "Наличието на оборудването е задължителна!")]
        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        [Required(ErrorMessage = "Наличието на оборудването е задължителна!")]
        public CarEquipmentBindingModel Diesel { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<CarServiceModel, CarEditInputModel>()
                .ForMember(destination => destination.Picture,
                            opts => opts.Ignore())
                .ForMember(destination => destination.CarStatus,
                            opts => opts.MapFrom(origin => origin.CarStatus.Name));

            configuration
                .CreateMap<CarEditInputModel, CarServiceModel>()
                .ForMember(destination => destination.CarStatus,
                            opts => opts.MapFrom(origin => new CarStatusServiceModel { Name = origin.CarStatus }));
        }
    }
}