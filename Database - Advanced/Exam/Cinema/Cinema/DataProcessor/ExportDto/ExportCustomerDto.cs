using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ExportDto
{
    public class ExportCustomerDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }
    }
}