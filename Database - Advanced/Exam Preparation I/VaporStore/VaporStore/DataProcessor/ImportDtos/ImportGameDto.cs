namespace VaporStore.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        // Tags > 0
        public List<string> Tags { get; set; }
    }
}