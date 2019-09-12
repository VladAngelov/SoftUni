using System;

namespace RentACar.Web.ViewModels.Car.Details
{
    using Service.Mapping;
    using Services.Models;
    using Web.BindingModels;

    public class CarDetailsViewModel : IMapFrom<CarServiceModel>, IMapTo<CarServiceModel>
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public CarGroupBindingModel Group { get; set; }

        public CarEquipmentBindingModel AirConditioner { get; set; }

        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        public CarEquipmentBindingModel Diesel { get; set; }

        public CarRentBindingModel CarRentBindingModel { get; set; }
    }
}