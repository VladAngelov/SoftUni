namespace RentACar.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rent
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public RentStatus Status { get; set; }

        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string UserId { get; set; }

        public RentACarUser User { get; set; }
    }
}