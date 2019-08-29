namespace RentACar.Web.BindingModels
{
    using AutoMapper;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarCreateBindingModel : IMapTo<CarServiceModel>/*, IHaveCustomMappings*/
    {
     //   private static string errorMessage = "Required!";

        [Required(ErrorMessage = "Required!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Required!")]
        public DateTime ManufacturedOn { get; set; }

        [Required(ErrorMessage = "Required!")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Required!")]
        public CarEquipment AirConditioner { get; set; }

        [Required(ErrorMessage = "Required!")]
        public CarEquipment AutomaticGearbox { get; set; }

        [Required(ErrorMessage = "Required!")]
        public CarEquipment Diesel { get; set; }

       // [Required(ErrorMessage = "Required!")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "Required!")]
        public CarGroup Group { get; set; }


        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration
        //        .CreateMap<CarCreateBindingModel, CarServiceModel>()
        //        .ForMember(destination => destination.Group,
        //                    opts => opts.MapFrom(origin => new CarGroupServiceModel { Id = (int)origin.Group }));
        //    // TODO: Refactor
        //}
    }
}