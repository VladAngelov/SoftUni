namespace RentACar.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public Car()
        {
            this.IsBooked = false;
        }

        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public CarGroup Group { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public bool IsBooked { get; set; }

      //  [Required]
        public CarEquipment AirConditioner { get; set; }

        //[Required]
        public CarEquipment AutomaticGearbox { get; set; }

        //[Required]
        public CarEquipment Diesel { get; set; }

        [Required]
        public string Picture { get; set; } 
    }
}