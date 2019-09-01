namespace RentACar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RentACarUser : IdentityUser
    {
        public RentACarUser()
        {
            this.Premium = false;
            this.Rents = new HashSet<Rent>();
        }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public bool Premium { get; set; }

        public ICollection<Rent> Rents { get; set; }

        private void IsPremium()
        {
            if (this.Rents.Count >= 3)
            {
                this.Premium = true;
            }
        }
    }
}