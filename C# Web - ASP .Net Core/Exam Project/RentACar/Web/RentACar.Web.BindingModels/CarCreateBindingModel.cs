namespace RentACar.Web.BindingModels
{
    using AutoMapper;
    using Service.Mapping;
    using Services.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarCreateBindingModel : IMapTo<CarServiceModel>, IHaveCustomMappings
    {
        // [Required(ErrorMessage = "Въведи марката на колата!")]
        // [StringLength(20, ErrorMessage = "Въведи валидна марка!", MinimumLength = 2)]
        // [Display(Name = "Марка")]
        [Required(ErrorMessage = "Enter brand of the car!")]
        [StringLength(20, ErrorMessage = "Enter valid brand - minimum length: 2 and maximum length: 20!", MinimumLength = 2)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        // [Required(ErrorMessage = "Въведи модел!")]
        // [StringLength(20, ErrorMessage = "Въведи валиден модел.", MinimumLength = 2)]
        // [Display(Name = "Модел")]
        [Required(ErrorMessage = "Enter model of the car!")]
        [StringLength(20, ErrorMessage = "Enter valid model - minimum length: 2 and maximum length: 20!", MinimumLength = 2)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        // [Required(ErrorMessage = "Въведи дата на създаване!")]
        [Required(ErrorMessage = "Enter valid date of manufacture!")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedOn { get; set; }

        // [Display(Name = "Цена на ден")]
        [Required]
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере!")]
        [Required(ErrorMessage = "Must be chosen!")]
        public CarEquipmentBindingModel AirConditioner { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере!")]
        [Required(ErrorMessage = "Must be chosen!")]
        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере!")]
        [Required(ErrorMessage = "Must be chosen!")]
        public CarEquipmentBindingModel Diesel { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере!")]
        [Required(ErrorMessage = "Must be chosen!")]
        public CarGroupBindingModel Group { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере снимка!")]
        [Required(ErrorMessage = "Select photo!")]
        public IFormFile Picture { get; set; }

        // [Required(ErrorMessage = "Задължително да се избере статус на колата!")]
        [Required(ErrorMessage = "Must be select status of the car!")]
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