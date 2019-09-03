namespace RentACar.Web.BindingModels
{
    using Service.Mapping;
    using Services.Models;
    using System.Collections.Generic;

    public class RentACarUserBindingModel : IMapTo<RentACarUserServiceModel>
    {

        public string FullName { get; set; }

        //public string Email { get; set; }

        //public string PhoneNumber { get; set; }

        public bool Premium { get; set; }

        public List<RentServiceModel> Rents { get; set; }
    }
}