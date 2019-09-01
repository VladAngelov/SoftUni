namespace RentACar.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rent
    {
        public int Id { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }

        public RentStatus Status { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public string UserId { get; set; }

        public RentACarUser User { get; set; }
    }
}