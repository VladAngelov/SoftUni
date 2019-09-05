namespace RentACar.Services.Models
{
    using Data.Models.Car;
    using Service.Mapping;

    public class CarStatusServiceModel : IMapFrom<CarStatus>, IMapTo<CarStatus>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}