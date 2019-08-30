namespace RentACar.Web.BindingModels
{
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarCreateBindingModel : IMapTo<CarServiceModel>
    {
        [Required(ErrorMessage = "Required brand!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Required model!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Required manufactured on date!")]
        public DateTime ManufacturedOn { get; set; }

        [Required(ErrorMessage = "Required price per day!")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Required availability!")]
        public CarEquipment AirConditioner { get; set; }

        [Required(ErrorMessage = "Required availability!")]
        public CarEquipment AutomaticGearbox { get; set; }

        [Required(ErrorMessage = "Required availability!")]
        public CarEquipment Diesel { get; set; }

        [Required(ErrorMessage = "Required picture!")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "Required car group!")]
        public CarGroup Group { get; set; }
    }
}