namespace RentACar.Web.BindingModels
{
    using Service.Mapping;
    using Services.Models;
    using System.Collections.Generic;

    public class RentACarUserBindingModel : IMapTo<UserServiceModel>
    {

        public string FullName { get; set; }

        public List<RentServiceModel> Rents { get; set; }
    }
}