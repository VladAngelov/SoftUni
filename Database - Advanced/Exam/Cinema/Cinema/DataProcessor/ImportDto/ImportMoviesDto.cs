namespace Cinema.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Data.Models.Enums;

    public class ImportMoviesDto
    {

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; }
    }
}