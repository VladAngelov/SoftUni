namespace RentACar.Web.ViewModels.Home.Index
{
    using RentACar.Web.BindingModels;
    using System;

    public class CarHomeViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public bool IsBooked { get; set; }

        public CarGroupBindingModel Group { get; set; }
    }
}