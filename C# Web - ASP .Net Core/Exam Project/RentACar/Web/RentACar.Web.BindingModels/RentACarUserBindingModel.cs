namespace RentACar.Web.BindingModels
{
    using Service.Mapping;
    using Services.Models;
    using System.Collections.Generic;

    public class RentACarUserBindingModel : IMapTo<RentACarUserServiceModel>
    {

        public string FullName { get; set; }

        public RentACarUserStatusServiceModel Premium { get; set; }

        public List<RentServiceModel> Rents { get; set; }
    }
}