namespace RentACar.Services.Models
{
    using Data.Models;
    using Service.Mapping;
    using System;

    public class RentServiceModel : IMapFrom<Rent>, IMapTo<Rent>
    {
        public int CarId { get; set; }

        public CarServiceModel Car { get; set; }

        public string UserId { get; set; }

        public RentACarUserServiceModel User { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RentStatusServiceModel Status { get; set; }
    }
}