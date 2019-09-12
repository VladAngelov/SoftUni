using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.BindingModels
{
    using AutoMapper;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;

    public class CarCreateBindingModel : IMapTo<CarServiceModel>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Въведи марката на колата!")]
        [StringLength(20, ErrorMessage = "Въведи валидна марка!", MinimumLength = 2)]
        [Display(Name = "Марка")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Въведи модел!")]
        [StringLength(20, ErrorMessage = "Въведи валиден модел.", MinimumLength = 2)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Въведи дата на създаване!")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        [Display(Name = "Цена на ден")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        public CarEquipmentBindingModel AirConditioner { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        public CarEquipmentBindingModel Diesel { get; set; }

        [Required(ErrorMessage = "Задължително да се избере група!")]
        public CarGroupBindingModel Group { get; set; }

        [Required(ErrorMessage = "Задължително да се избере снимка!")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "Задължително да се избере статус на колата!")]
        public string CarStatus { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<CarCreateBindingModel, CarServiceModel>()
                .ForMember(destination => destination.CarStatus,
                            opts => opts.MapFrom(origin => new CarStatusServiceModel { Name = origin.CarStatus }));
        }
    }
}