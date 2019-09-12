using System;

namespace RentACar.Web.ViewModels.Home.Index
{
    using Service.Mapping;
    using Services.Models;
    using Web.BindingModels;

    public class CarHomeViewModel : IMapFrom<CarServiceModel>
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string CarStatus { get; set; }

        public CarGroupBindingModel Group { get; set; }
    }
}