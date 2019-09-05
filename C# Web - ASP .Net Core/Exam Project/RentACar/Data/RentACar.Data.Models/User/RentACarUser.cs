namespace RentACar.Data.Models.User
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Rent;

    public class RentACarUser : IdentityUser
    {
        private string fullName;

        public RentACarUser()
        {
            this.Rents = new HashSet<Rent>();
            this.StatusId = 1;
        }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = FirstName + " " + LastName;
            }
        }

        public int StatusId { get; set; }

        public RentACarUserStatus Status { get; set; }

        public ICollection<Rent> Rents { get; set; }

        private void IsPremium()
        {
            if (this.Rents.Count >= 3)
            {
                this.Status.Name = "Premium";
            }
        }
    }
}