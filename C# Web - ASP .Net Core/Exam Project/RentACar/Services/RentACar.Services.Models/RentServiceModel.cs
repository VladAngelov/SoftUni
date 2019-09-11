namespace RentACar.Services.Models
{
    using Data.Models.Rent;
    using Service.Mapping;
    using System;

    public class RentServiceModel //: IMapFrom<Rent>, IMapTo<Rent>
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public CarServiceModel Car { get; set; }

        public string UserId { get; set; }

        public UserServiceModel User { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RentStatusServiceModel Status { get; set; }

        public decimal Fee { get; set; }

        public int CarStatusId { get; set; }

        public CarStatusServiceModel CarStatus { get; set; }
    }
}