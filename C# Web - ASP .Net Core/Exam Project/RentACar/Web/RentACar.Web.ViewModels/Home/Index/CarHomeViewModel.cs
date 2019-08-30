namespace RentACar.Web.ViewModels.Home.Index
{
    using RentACar.Web.BindingModels;
    using System;

    public class CarHomeViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public decimal PricePerDay { get; set; }

        public string Picture { get; set; }

        public CarGroupBindingModel CarGroup { get; set; }

        public CarEquipmentBindingModel AirConditioner { get; set; }

        public CarEquipmentBindingModel AutomaticGearbox { get; set; }

        public CarEquipmentBindingModel Disel { get; set; }

        public bool IsBooked { get; set; }
    }
}