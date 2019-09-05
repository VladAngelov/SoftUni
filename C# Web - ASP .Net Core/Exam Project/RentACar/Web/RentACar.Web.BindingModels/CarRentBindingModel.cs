namespace RentACar.Web.BindingModels
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;

    public class CarRentBindingModel : IMapTo<RentServiceModel>
    {
        public int CarId { get; set; }

        public RentACarUserBindingModel User { get; set; }
    }
}