namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        {
            this.GameTags = new HashSet<GameTag>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<GameTag> GameTags { get; set; }
    }
}