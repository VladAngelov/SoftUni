﻿namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // TODO: Check Customer – the customer’s ticket 

        [Required]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }

        // TODO: Check Projection – the projection’s ticket
    }
}