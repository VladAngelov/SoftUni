namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Genre
    {
        public Genre()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}