namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Developer
    {
        public Developer()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}