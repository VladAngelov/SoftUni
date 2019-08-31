namespace RentACar.Services.Models
{
    using Data.Models;
    using Service.Mapping;
    using System;

    public class CarServiceModel : IMapFrom<Car>, IMapTo<Car>
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public CarGroup Group { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsBooked { get; set; }

        public CarEquipment AirConditioner { get; set; }

        public CarEquipment AutomaticGearbox { get; set; }

        public CarEquipment Diesel { get; set; }

        public string Picture { get; set; }
    }
}