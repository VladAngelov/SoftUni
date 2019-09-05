namespace RentACar.Web.BindingModels
{
    using RentACar.Service.Mapping;
    using RentACar.Services.Models;

    public class RentACarCarStatusBindingModel : IMapTo<RentACarUserStatusServiceModel>
    {
        public string Name { get; set; }
    }
}