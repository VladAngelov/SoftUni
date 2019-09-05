namespace RentACar.Web.ViewModels.Car.Details
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using System;

    public class CarDetailsViewModel : IMapFrom<CarServiceModel>
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public CarGroupBindingModel Group { get; set; }

        public CarStatusBindingModel CarStatus { get; set; } //??
    }
}