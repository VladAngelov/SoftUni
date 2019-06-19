namespace Cinema.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TopMovieDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string MovieName { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        public decimal TotalIncomes { get; set; }

        public ICollection<ExportCustomerDto> Customers { get; set; }
    }
}