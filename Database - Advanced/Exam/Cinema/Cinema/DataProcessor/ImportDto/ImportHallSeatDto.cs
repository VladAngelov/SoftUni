namespace Cinema.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;

    public class ImportHallSeatDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public bool Is4Dx { get; set; }

        [Required]
        public bool Is3D { get; set; }

        [Required]
        public int Seats { get; set; }
    }
}