namespace RentACar.Web.ViewModels.Car.Delete
{
    using Service.Mapping;
    using Services.Models;
    using System;

    public class CarDeleteViewModel : IMapFrom<CarServiceModel>
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }
    }
}