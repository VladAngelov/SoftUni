using System;

namespace RentACar.Web.ViewModels.Home.Index
{
    public class CarHomeViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public bool IsBooked { get; set; }
    }
}