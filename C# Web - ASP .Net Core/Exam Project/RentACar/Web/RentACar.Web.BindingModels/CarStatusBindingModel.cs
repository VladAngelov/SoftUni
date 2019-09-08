namespace RentACar.Web.BindingModels
{
    using Service.Mapping;
    using Services.Models;

    public class CarStatusBindingModel : IMapFrom<CarStatusServiceModel>, IMapTo<CarStatusServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}