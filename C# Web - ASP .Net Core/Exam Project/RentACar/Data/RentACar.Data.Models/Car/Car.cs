namespace RentACar.Data.Models.Car
{
    using System;

    public class Car
    {
        public Car()
        {
            //this.CarStatus.Name = "Free";
        }

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public CarGroup Group { get; set; }

        public decimal PricePerDay { get; set; }

     //   public int CarStatusId { get; set; }

        public CarStatus CarStatus { get; set; }

        public CarEquipment AirConditioner { get; set; }

        public CarEquipment AutomaticGearbox { get; set; }

        public CarEquipment Diesel { get; set; }

        public string Picture { get; set; }
    }
}