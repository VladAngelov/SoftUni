namespace RentACar.Web.BindingModels
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarCreateBindingModel : IMapTo<CarServiceModel>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Въведи марката на колата!")]
        [StringLength(20, ErrorMessage = "Въведи валидна марка!", MinimumLength = 2)]
        [Display(Name = "Марка")]
        //[Required(ErrorMessage = "Required brand!")]
        //[StringLength(20, ErrorMessage = "Brand invalid.", MinimumLength = 2)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Въведи модел!")]
        [StringLength(20, ErrorMessage = "Въведи валиден модел.", MinimumLength = 2)]
        [Display(Name = "Модел")]
        //[Required(ErrorMessage = "Required model!")]
        //[StringLength(20, ErrorMessage = "Model invalid.", MinimumLength = 2)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Въведи дата на създаване!")]
        //[Required(ErrorMessage = "Required manufactured on date!")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        //[Range(typeof(decimal), "0,00m", "79228162514264337593543950335", 
        //    ErrorMessage = "Цената за ден, трябва да бъде позитивно число!")]
        //[Range(typeof(decimal), "0,00", "79228162514264337593543950335", ErrorMessage = "Price per day must be a positive number!")]
        [Display(Name = "Цена на ден")]
        //[Display(Name = "PricePerDay")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        //[Required(ErrorMessage = "Required availability!")]
        public CarEquipmentBindingModel AirConditioner { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        //[Required(ErrorMessage = "Required availability!")]
        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        [Required(ErrorMessage = "Задължително да се избере!")]
        //[Required(ErrorMessage = "Required availability!")]
        public CarEquipmentBindingModel Diesel { get; set; }

        [Required(ErrorMessage = "Задължително да се избере група!")]
        //[Required(ErrorMessage = "Required car group!")]
        public CarGroupBindingModel Group { get; set; }

        [Required(ErrorMessage = "Задължително да се избере снимка!")]
        //[Required(ErrorMessage = "Required picture!")]
        public IFormFile Picture { get; set; }

        public string CarStatus { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<CarCreateBindingModel, CarServiceModel>()
                .ForMember(destination => destination.Status,
                            opts => opts.MapFrom(origin => new CarStatusServiceModel { Name = origin.CarStatus }));
        }
    }
}