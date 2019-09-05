namespace RentACar.Services.Models
{
    using Data.Models.Rent;
    using Service.Mapping;

    public class RentStatusServiceModel : IMapFrom<RentStatus>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}